using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace server.Services.SignalR
{
    public interface ISignalRMemberService
    {
        void AddConnection(HubCallerContext context);

        int GetOnlineUsers();

        int GetVisitorCount();
    }
}
