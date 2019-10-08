using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Services.SignalR.Broadcasters
{
    public interface IChatHub
    {
        Task JoinGroup(string groupName);
        Task LeaveGroup(string groupName);

        Task SendMessage(string message);
        Task SendMessage(string user, string message);
    }
}
