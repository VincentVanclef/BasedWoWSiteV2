using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using server.Data.Website;
using server.Services.Ravendb;
using server.Services.SignalR.Chat;

namespace server.Services.SignalR
{
    public class SignalRHub : Hub<ISignalRHub>
    {
        private readonly IGroupChatService _groupChatService;
        private readonly string _websiteVersion;

        public SignalRHub(IConfiguration configuration, IGroupChatService groupChatService)
        {
            _groupChatService = groupChatService;
            _websiteVersion = configuration.GetSection("Version").Value;
        }

        public override async Task OnConnectedAsync()
        {
            SignalRMemberService.AddConnection(Context);

            await UpdateOnlineUsers(SignalRMemberService.GetOnlineUsers(), SignalRMemberService.GetVisitorCount());

            await _groupChatService.AddUserConnectionToGroupsAsync(Context.UserIdentifier, Context.ConnectionId);

            await ValidateVersion();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            SignalRMemberService.RemoveConnection(Context);

            await UpdateOnlineUsers(SignalRMemberService.GetOnlineUsers(), SignalRMemberService.GetVisitorCount());
        }

        public async Task UpdateOnlineUsers(WebsiteClient[] userCount, int visitorCount)
        {
            await Clients.All.UpdateOnlineUsers(userCount, visitorCount);
        }

        public async Task ValidateVersion()
        {
            await Clients.Client(Context.ConnectionId).ValidateVersion(_websiteVersion);
        }

        /* CHAT SYSTEM */
        public async Task SendGroupChatMessage(ChatMessageRequest request)
        {
            var groupChat = await _groupChatService.GetGroupChatByIdAsync(request.GroupId);
            if (groupChat == null)
                return;

            groupChat.ChatMessages.Add(new ChatMessage
            {
                Id = Guid.NewGuid(),
                SenderId = Context.UserIdentifier,
                Message = request.Message,
                DateTime = DateTime.Now
            });

            await _groupChatService.SaveGroupChatAsync(groupChat);
            await GroupChatUpdated(groupChat);
        }

        public async Task DeleteGroupChatMessage(ChatMessageDeleteRequest request)
        {
            var groupChat = await _groupChatService.GetGroupChatByIdAsync(request.GroupId);
            if (groupChat == null)
                return;

            groupChat.ChatMessages.RemoveAll(x => x.Id == request.MessageId);

            await _groupChatService.SaveGroupChatAsync(groupChat);
            await GroupChatUpdated(groupChat);
        }

        public async Task EditGroupChatMessage(EditChatMessageRequest request)
        {
            var groupChat = await _groupChatService.GetGroupChatByIdAsync(request.GroupId);
            if (groupChat == null)
                return;

            var message = groupChat.ChatMessages.FirstOrDefault(x => x.Id == request.Message.Id);
            if (message != null)
            {
                message.Message = request.Message.Message;
            }

            await _groupChatService.SaveGroupChatAsync(groupChat);
            await GroupChatUpdated(groupChat);
        }

        public async Task LeaveGroupChat(GroupChatLeaveRequest request)
        {
            var groupChat = await _groupChatService.GetGroupChatByIdAsync(request.GroupId);
            if (groupChat == null)
                return;

            _groupChatService.DeleteGroupChat(groupChat);
            await Clients.Group(groupChat.Id).GroupChatRemoved(request.GroupId, Context.User.Identity.Name);
        }

        public async Task GroupChatUpdated(GroupChat groupChat)
        {
            await Clients.Group(groupChat.Id).GroupChatUpdated(groupChat);
        }
    }
}
