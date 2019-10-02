using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;

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
    }
}
