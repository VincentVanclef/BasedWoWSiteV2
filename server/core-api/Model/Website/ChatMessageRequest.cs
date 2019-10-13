using System.ComponentModel.DataAnnotations;

namespace server.Model.Website
{
    public class ChatMessageRequest
    {
        [Required]
        public string GroupId { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
