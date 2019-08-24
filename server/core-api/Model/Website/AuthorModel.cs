using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Model.Website
{
    public class AuthorModel
    {
        [Required]
        public Guid Author { get; set; }

        [NotMapped]
        public string AuthorName { get; set; }
    }
}
