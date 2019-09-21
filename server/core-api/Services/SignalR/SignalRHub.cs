using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace server.Services.SignalR
{
    public class SignalRHub : Hub<ISignalRHub>
    {
        private static int _onlineCount;

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

        public async Task UpdateOnlineUsers(int count)
        {
            await Clients.All.UpdateOnlineUsers(count);
        }
    }
}
