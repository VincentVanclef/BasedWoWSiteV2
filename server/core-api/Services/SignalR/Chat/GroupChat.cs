using System;
using System.Collections.Generic;
using server.Util;

namespace server.Services.SignalR.Chat
{
    [Serializable]
    public class GroupChat
    {
        public string Id { get; set; }
        public List<GroupChatMember> Members { get; set; }
        public FixedList<ChatMessage> ChatMessages { get; set; } = new FixedList<ChatMessage>();
        public DateTime LastModified { get; set; }
    }
}