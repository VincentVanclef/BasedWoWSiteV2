using System.ComponentModel.DataAnnotations;

namespace server.Model.Website
{
    public class GroupChatLeaveRequest
    {
        [Required]
        public string GroupId { get; set; }
    }
}
