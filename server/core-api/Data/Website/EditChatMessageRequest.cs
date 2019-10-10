using System.ComponentModel.DataAnnotations;
using server.Services.SignalR.Chat;

namespace server.Data.Website
{
    public class EditChatMessageRequest
    {
        [Required]
        public string GroupId { get; set; }

        [Required]
        public ChatMessage Message { get; set; }
    }
}
