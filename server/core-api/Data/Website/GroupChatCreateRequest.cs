using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using server.Services.SignalR;

namespace server.Data.Website
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