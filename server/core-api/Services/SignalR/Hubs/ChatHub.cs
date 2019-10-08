using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using server.Services.SignalR.Broadcasters;

namespace server.Services.SignalR.Hubs
{
    public class ChatHub : Hub<IChatHub>
    {
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string message)
        {
            await Clients.All.SendMessage(Context.User.Identity.Name, message);
        }

        public async Task CreateGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task SendGroupMessage(string groupName, string message)
        {
            await Clients.OthersInGroup(groupName).SendMessage(message);
        }
    }
}
