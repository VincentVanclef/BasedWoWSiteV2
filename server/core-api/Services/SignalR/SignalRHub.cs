using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using server.Data.Website;

namespace server.Services.SignalR
{
    public class SignalRHub : Hub<ISignalRHub>
    {
        private static int _onlineCount = 0;

        public override async Task OnConnectedAsync()
        {
            ++_onlineCount;
            await UpdateOnlineUsers(_onlineCount);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            --_onlineCount;
            await UpdateOnlineUsers(_onlineCount);
        }

        public async Task SendMessage(string message)
        {
            await Clients.All.ReceiveMessage(message);
        }

        public async Task UpdateOnlineUsers(int count)
        {
            await Clients.All.UpdateOnlineUsers(count);
        }

        public async Task UpdateUserInformations(string user, int count)
        {
            await Clients.All.UpdateUserInformations(user, count);
        }
    }
}
