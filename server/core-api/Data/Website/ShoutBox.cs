using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Data.Website
{
    public class ShoutBoxMessage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; set; }

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
