using System;
using System.Collections.Generic;

namespace server.Services.SignalR.Chat
{
    [Serializable]
    public class GroupChat
    {
        public string Id { get; set; }
        public List<GroupChatMember> Members { get; set; }
        public List<ChatMessage> ChatMessages { get; set; } = new List<ChatMessage>();
        public DateTime LastModified { get; set; }
    }
}