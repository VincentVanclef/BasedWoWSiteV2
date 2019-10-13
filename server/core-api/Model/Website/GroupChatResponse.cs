using System.Collections.Generic;
using server.Services.SignalR.Chat;

namespace server.Model.Website
{
    public class GroupChatResponse
    {
        public GroupChat Group { get; set; }
        public List<GroupChatMessage> GroupChatMessages { get; set; }
    }
}