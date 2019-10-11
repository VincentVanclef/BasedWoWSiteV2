using System;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace server.Services.SignalR.Chat
{
    public class ChatMessage
    {
        public Guid Id { get; set; }
        public string SenderId { get; set; }
        public string Message { get; set; } 
        public DateTime DateTime { get; set; }
        public bool Read { get; set; }
    }
}
