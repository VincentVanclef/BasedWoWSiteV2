using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace server.Services.SignalR.Chat
{
    public class ChatMessage
    {
        public ChatMessage()
        {
            
        }

        public ChatMessage(string senderId, string receiverId, string message)
        {
            SenderId = senderId;
            ReceiverId = receiverId;
            Message = message;
        }

        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string Message { get; set; }
    }

    public class GroupChatMessage : ChatMessage
    {
        public GroupChatMessage()
        {
            
        }

        public GroupChatMessage(string groupName, string message, string senderId, string receiverId = "")
        {
            SenderId = senderId;
            ReceiverId = receiverId;
            GroupName = groupName;
            Message = message;
        }

        public string GroupName { get; set; }
    }

    [Serializable]
    public class GroupChat
    {
        [JsonProperty("groupId")]
        public string GroupId { get; set; }

        [JsonProperty("members")]
        public List<WebsiteClient> Members { get; set; }
    }
}
