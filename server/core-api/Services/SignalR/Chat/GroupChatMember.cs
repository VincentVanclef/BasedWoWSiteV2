using System;

namespace server.Services.SignalR.Chat
{
    public class GroupChatMember
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime LastAccessed { get; set; }
    }
}
