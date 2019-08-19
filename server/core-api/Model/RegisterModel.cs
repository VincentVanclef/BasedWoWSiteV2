using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.Model
{
    public class RegisterModel
    {
        [Required]
        [MinLength(8)]
        [MaxLength(16)]
        public string Username { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(16)]
        public string Firstname { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(16)]
        public string Lastname { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(16)]
        public string Password { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
