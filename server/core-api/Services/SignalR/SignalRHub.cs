using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using MySqlX.XDevAPI;

namespace server.Services.SignalR
{
    public class SignalRHub : Hub<ISignalRHub>
    {
        private readonly string _websiteVersion;

        public SignalRHub(IConfiguration configuration)
        {
            _websiteVersion = configuration.GetSection("Version").Value;
        }

        private static int _onlineCount;

        public override async Task OnConnectedAsync()
        {
            ++_onlineCount;
            await UpdateOnlineUsers(_onlineCount);
            await ValidateVersion();
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

        public async Task ValidateVersion()
        {
            await Clients.Client(Context.ConnectionId).ValidateVersion(_websiteVersion);
        }
    }
}
