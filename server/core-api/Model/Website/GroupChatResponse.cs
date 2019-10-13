using System.Collections.Generic;
using server.Services.SignalR.Chat;

namespace server.Data.Website
{
    public class GroupChatResponse
    {
        public GroupChat Group { get; set; }
        public List<GroupChatMessage> GroupChatMessages { get; set; }
    }
}