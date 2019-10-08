using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using server.Services.SignalR;
using server.Services.SignalR.Broadcasters;
using server.Services.SignalR.Hubs;

namespace server.Controllers
{
    [Authorize]
    [Route("/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<SignalRHub, ISignalRHub> _chatHub;

        public ChatController(IHubContext<SignalRHub, ISignalRHub> chatHub)
        {
            _chatHub = chatHub;
        }

    }
}