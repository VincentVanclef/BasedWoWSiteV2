using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
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
        Task DeleteShout(int id);
    }
}
