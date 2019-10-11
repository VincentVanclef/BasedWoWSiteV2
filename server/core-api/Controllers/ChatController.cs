using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Linq;
using server.ApiExtensions;
using server.Data.Website;
using server.Services.Ravendb;
using server.Services.SignalR;
using server.Services.SignalR.Chat;
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
            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return RequestHandler.Unauthorized();

            var otherMember = user.Id.ToString() == request.Members[0].Id ? request.Members[1] : request.Members[0];

            var groupChat = await _groupChatService.GetExistingGroupChatAsync(user.Id.ToString(), otherMember.Id);
            if (groupChat != null)
                return RequestHandler.BadRequest($"You are already in a group chat with {otherMember.Name}");

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
                member.Clients.ForEach(async x =>
                {
                    await _signalRHub.Groups.AddToGroupAsync(x.ConnectionId, groupChat.Id);

                    if (member.Id == user.Id.ToString())
                        await _signalRHub.Clients.Client(x.ConnectionId).GroupChatUpdated(groupChat);
                    else
                        await _signalRHub.Clients.Client(x.ConnectionId).GroupChatCreated(groupChat, user.UserName);
                });
            }

            return Ok();
        }
    }
}