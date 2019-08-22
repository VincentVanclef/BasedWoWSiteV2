using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace server.Data.Website
{
    public class ShoutBox
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public Guid User { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(200)]
        public string Message { get; set; }

        public DateTime Date { get; set; }

        [NotMapped]
        public string Username { get; set; }

        [NotMapped]
        public string Email { get; set; }
    }
}
