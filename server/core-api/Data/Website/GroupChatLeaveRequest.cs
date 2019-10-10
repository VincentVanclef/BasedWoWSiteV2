using System.ComponentModel.DataAnnotations;

namespace server.Data.Website
{
    public class GroupChatLeaveRequest
    {
        [Required]
        public string GroupId { get; set; }
    }
}
