using System.ComponentModel.DataAnnotations;

namespace server.Model.Website
{
    public class GroupChatCreateRequest
    {
        [Required]
        public string MemberId { get; set; }

        [Required]
        public string MemberName { get; set; }

        [Required]
        public string MemberEmail { get; set; }
    }
}