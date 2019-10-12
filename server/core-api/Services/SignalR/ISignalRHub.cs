using System.Threading.Tasks;
using server.Data.Website;
using server.Services.SignalR.Chat;

namespace server.Services.SignalR
{
    public interface ISignalRHub
    {
        Task UpdateOnlineUsers(WebsiteClient[] userCount, int visitorCount);
        Task UpdateUserInformations(UserInformationResponse response, int count);
        Task ReceiveShoutBoxMessage(ShoutBox shout);
        Task ClearShoutBox();
        Task EditShout(ShoutBox shout);
        Task DeleteShout(uint id);
        Task ValidateVersion(string version);

        /* CHAT SYSTEM */
        Task SendMessage(ChatMessage message);
        Task GroupChatCreated(GroupChat groupChat, string createdBy);
        Task GroupChatUpdated(GroupChat groupChat);
        Task GroupChatRemoved(string id, string leaverName);
    }
}
