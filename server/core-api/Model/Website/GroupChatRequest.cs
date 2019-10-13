using System.ComponentModel.DataAnnotations;

namespace server.Model.Website
{
    public class GroupChatRequest
    {
        [Required]
        public string ConnectionId { get; set; }
    }
}