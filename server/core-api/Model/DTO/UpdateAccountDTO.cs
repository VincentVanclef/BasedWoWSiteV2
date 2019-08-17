using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.Model.DTO
{
    public class UpdateAccountDTO
    {
        [Required]
        public int Id { get; set; }
        public string NewUsername { get; set; }
        public string NewPassword { get; set; }
        [Required]
        public string CurrentUsername { get; set; }
        [Required]
        public string CurrentPassword { get; set; }
    }
}
