using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.Data.Website
{
    public class ChatMessageRequest
    {
        [Required]
        public string GroupId { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
