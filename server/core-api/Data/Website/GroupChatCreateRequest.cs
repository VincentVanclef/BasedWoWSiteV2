using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using server.Services.SignalR;

namespace server.Data.Website
{
    public class GroupChatCreateRequest
    {
        [Required]
        [MinLength(2)]
        public List<WebsiteClient> Members { get; set; }
    }
}