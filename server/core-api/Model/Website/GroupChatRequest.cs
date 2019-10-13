using System.ComponentModel.DataAnnotations;

namespace server.Data.Website
{
    public class GroupChatRequest
    {
        [Required]
        public string ConnectionId { get; set; }
    }
}