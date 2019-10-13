using System;
using System.ComponentModel.DataAnnotations;

namespace server.Model.Website
{
    public class ChatMessageDeleteRequest
    {
        [Required]
        public string GroupId { get; set; }

        [Required]
        public Guid MessageId { get; set; }
    }
}
