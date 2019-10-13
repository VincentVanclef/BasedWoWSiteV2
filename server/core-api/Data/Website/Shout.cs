using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace server.Data.Website
{
    public class Shout
    {
        public string Id { get; set; }

        [Required]
        public Guid User { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(200)]
        public string Message { get; set; }

        public DateTime Date { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }
    }
}