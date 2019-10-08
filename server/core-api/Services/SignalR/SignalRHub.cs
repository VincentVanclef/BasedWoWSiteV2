using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using server.Services.SignalR.Chat;

namespace server.Services.SignalR
{
    public class SignalRHub : Hub<ISignalRHub>
    {
        private readonly string _websiteVersion;

        public SignalRHub(IConfiguration configuration)
        {
            _websiteVersion = configuration.GetSection("Version").Value;
        }

        public override async Task OnConnectedAsync()
        {
            SignalRMemberService.AddConnection(Context);

            await UpdateOnlineUsers(SignalRMemberService.GetOnlineUsers(), SignalRMemberService.GetVisitorCount());

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
        public async Task CreateGroupChat(GroupChat groupChat)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupChat.GroupId);

            foreach (var member in groupChat.Members)
            {
                member.Clients.ForEach(async x => await Groups.AddToGroupAsync(x.ConnectionId, groupChat.GroupId));
            }

            var groupOwnerName = Context.User.Identity.Name;
            var groupOwnerId = Context.UserIdentifier;

            await SendGroupMessage(new GroupChatMessage(groupChat.GroupId,
                $"{groupOwnerName} has started a group chat with you.", groupOwnerId));

            await ConfirmCreatedGroupChat(groupChat);
        }

        public async Task SendMessage(ChatMessage message)
        {
            var connections = SignalRMemberService.GetConnectionsByUser(message.ReceiverId);
            if (connections != null)
            {
                foreach (var connectionId in connections)
                {
                    await Clients.Client(connectionId).SendMessage(message);
                }
            }
        }

        public async Task SendGroupMessage(GroupChatMessage message)
        {
            await Clients.Group(message.GroupName).SendMessage(message.Message);
        }

        public async Task ConfirmCreatedGroupChat(GroupChat groupChat)
        {
            await Clients.Group(groupChat.GroupId).GroupChatUpdated(groupChat);
        }
    }
}
