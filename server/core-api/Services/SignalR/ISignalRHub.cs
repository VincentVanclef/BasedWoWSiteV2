using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace server.Services.SignalR
{
    public interface ISignalRHub
    {
        Task UpdateOnlineUsers(int count);
        Task ReceiveMessage(string message);
        Task UpdateUserInformations(string user, int count);
    }
}
