using System;
using System.ComponentModel.DataAnnotations;

namespace server.Model.Website
{
    public class NewNewsModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public Guid Author { get; set; }
    }
}
