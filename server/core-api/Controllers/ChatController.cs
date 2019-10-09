using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Internal;
using Raven.Client.Documents;
using System.Linq;
using server.ApiExtensions;
using server.Data.Characters;
using server.Data.Website;
using server.Services.Ravendb;
using server.Services.SignalR;
using server.Services.SignalR.Broadcasters;
using server.Services.SignalR.Chat;
using server.Services.SignalR.Hubs;
using server.Util;

namespace server.Controllers
{
    [Authorize]
    [Route("/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHubContext<SignalRHub, ISignalRHub> _signalRHub;
        private readonly IGroupChatService _groupChatService;

        public ChatController(UserManager<ApplicationUser> userManager, IHubContext<SignalRHub, ISignalRHub> chatHub, IDocumentStoreHolder documentStore, 
            IGroupChatService groupChatService)
        {
            _userManager = userManager;
            _signalRHub = chatHub;
            _groupChatService = groupChatService;
        }

        [HttpGet("GetGroupChats")]
        public async Task<IActionResult> GetGroupChats()
        {
            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return RequestHandler.Unauthorized();

            var groupChats = await _groupChatService.GetGroupChatsByMemberIdAsync(user.Id.ToString());
            
            return Ok(groupChats);
        }

        [HttpPost("CreateGroupChat")]
        public async Task<IActionResult> CreateGroupChat([FromBody] GroupChatCreateRequest request)
        {
            var memberGuidOne = request.Members[0].Id;
            var memberGuidTwo = request.Members[1].Id;

            var groupChat = await _groupChatService.GetExistingGroupChatAsync(memberGuidOne, memberGuidTwo);
            if (groupChat != null)
                return RequestHandler.BadRequest("You are already in a group with this user");

            groupChat = new GroupChat
            {
                Id = "",
                Members = request.Members.Select(x => new GroupChatMember
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    LastAccessed = DateTime.Now
                }).ToList()
            };

            await _groupChatService.SaveGroupChatAsync(groupChat);

            foreach (var member in request.Members)
            {
                member.Clients.ForEach(async x => await _signalRHub.Groups.AddToGroupAsync(x.ConnectionId, groupChat.Id));
            }

            await _signalRHub.Clients.Group(groupChat.Id).GroupChatUpdated(groupChat);

            return Ok();
        }
    }
}