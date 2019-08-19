using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

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
    }
}
