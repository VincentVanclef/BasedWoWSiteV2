using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Raven.Client.Documents;
using Raven.Client.Documents.Operations;
using Raven.Client.Documents.Queries;
using server.ApiExtensions;
using server.Context;
using server.Data.Website;
using server.Model.Website;
using server.Services.Ravendb;
using server.Services.Ravendb.Index;
using server.Services.SignalR;
using server.Util;

namespace server.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ShoutBoxController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly WebsiteContext _websiteContext;
        private readonly IHubContext<SignalRHub, ISignalRHub> _signalRHub;
        private readonly IDocumentStoreHolder _documentStoreHolder;

        public ShoutBoxController(UserManager<ApplicationUser> userManager, WebsiteContext websiteContext, IHubContext<SignalRHub, ISignalRHub> signalRHub, IDocumentStoreHolder documentStoreHolder)
        {
            _websiteContext = websiteContext;
            _userManager = userManager;
            _signalRHub = signalRHub;
            _documentStoreHolder = documentStoreHolder;
        }

        [HttpPost("GetShouts")]
        public async Task<IActionResult> GetShouts([FromBody] ShoutBoxRequest request)
        {
            List<Shout> shouts;

            using (var session = _documentStoreHolder.Store.OpenAsyncSession())
            {
                shouts = await session.Query<Shout, Shouts_ByDate>().Take(request.Count).OrderBy(o => o.Date).ToListAsync();
            }

            await GetAuthorDetails(shouts);

            return Ok(shouts);
        }

        [HttpGet("GetAllShouts")]
        public async Task<IActionResult> GetAllShouts()
        {
            List<Shout> shouts;

            using (var session = _documentStoreHolder.Store.OpenAsyncSession())
            {
                shouts = await session.Query<Shout>().ToListAsync();
            }

            return Ok(shouts);
        }

        [Authorize]
        [HttpPost("Shout")]
        public async Task<IActionResult> Shout([FromBody] ShoutBoxModel model)
        {
            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return RequestHandler.Unauthorized();

            var shout = new Shout
            {
                Message = model.Message,
                User = user.Id,
                Date = DateTime.UtcNow,
                Email = user.Email,
                Username = user.UserName.Capitalize()
            };

            using (var session = _documentStoreHolder.Store.OpenAsyncSession())
            {
                await session.StoreAsync(shout);
                await session.SaveChangesAsync();
            }

            await _signalRHub.Clients.All.ReceiveShoutBoxMessage(shout);

            return Ok();
        }

        [Authorize]
        [HttpPost("ClearShouts")]
        public async Task<IActionResult> ClearShouts()
        {
            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return RequestHandler.Unauthorized();

            if (!User.IsInRole("Admin"))
                return RequestHandler.Unauthorized();

            _documentStoreHolder.Store
                .Operations
                .Send(new DeleteByQueryOperation<Shout, Shouts_ByDate>(x => x.Date != null));

            await _signalRHub.Clients.All.ClearShoutBox();

            return Ok();
        }

        [Authorize]
        [HttpPost("EditShout")]
        public async Task<IActionResult> EditShout([FromBody] Shout shout)
        {
            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return RequestHandler.Unauthorized();

            if (!shout.User.Equals(user.Id))
            {
                if (!User.IsInRole("Admin") && !User.IsInRole("Moderator"))
                    return RequestHandler.Unauthorized();
            }

            using (var session = _documentStoreHolder.Store.OpenAsyncSession())
            {
                await session.StoreAsync(shout);
                await session.SaveChangesAsync();
            }

            await _signalRHub.Clients.All.EditShout(shout);

            return Ok();
        }

        [Authorize]
        [HttpPost("DeleteShout/")]
        public async Task<IActionResult> DeleteShout([FromBody] ShoutByIdRequest request)
        {
            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return RequestHandler.Unauthorized();

            using (var session = _documentStoreHolder.Store.OpenSession())
            {
                var shout = session.Load<Shout>(request.Id);

                if (shout == null)
                    return RequestHandler.BadRequest($"Shout with id {request.Id} does not exist");

                if (!shout.User.Equals(user.Id))
                {
                    if (!User.IsInRole("Admin") && !User.IsInRole("Moderator"))
                        return RequestHandler.Unauthorized();
                }

                session.Delete(shout);
                session.SaveChanges();
            }

            await _signalRHub.Clients.All.DeleteShout(request.Id);

            return Ok();
        }

        private async Task GetAuthorDetails(IEnumerable<Shout> shouts)
        {
            var authorCache = new Dictionary<string, Tuple<string, string>>();

            foreach (var author in shouts)
            {
                var userId = author.User.ToString();
                if (authorCache.TryGetValue(userId, out var cache))
                {
                    author.Username = cache.Item1;
                    author.Email = cache.Item2;
                    continue;
                }

                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                    continue;

                var authorName = user.UserName.Capitalize();
                author.Username = authorName;
                author.Email = user.Email;
                authorCache.Add(userId, Tuple.Create(authorName, user.Email));
            }
        }
    }
}