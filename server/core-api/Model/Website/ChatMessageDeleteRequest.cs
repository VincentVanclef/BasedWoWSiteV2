using System;
using System.ComponentModel.DataAnnotations;

namespace server.Data.Website
{
    public class ChatMessageDeleteRequest
    {
        [Required]
        public string GroupId { get; set; }

        [Required]
        public Guid MessageId { get; set; }
    }
}
