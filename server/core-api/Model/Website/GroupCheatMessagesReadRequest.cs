using System.ComponentModel.DataAnnotations;

namespace server.Model.Website
{
    public class GroupCheatMessagesReadRequest
    {
        [Required]
        public string GroupId { get; set; }
    }
}
