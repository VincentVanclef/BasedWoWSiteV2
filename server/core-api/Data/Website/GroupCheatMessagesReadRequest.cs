using System.ComponentModel.DataAnnotations;

namespace server.Data.Website
{
    public class GroupCheatMessagesReadRequest
    {
        [Required]
        public string GroupId { get; set; }
    }
}
