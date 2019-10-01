using System.Threading.Tasks;
using server.Data.Website;

namespace server.Services.SignalR
{
    public interface ISignalRHub
    {
        Task UpdateOnlineUsers(int count);
        Task ReceiveMessage(string message);
        Task UpdateUserInformations(string user, int count);
        Task ReceiveShoutBoxMessage(ShoutBox shout);
        Task ClearShoutBox();
        Task EditShout(ShoutBox shout);
        Task DeleteShout(uint id);
        Task LogoutUser();
        Task ValidateVersion(string version);
    }
}
