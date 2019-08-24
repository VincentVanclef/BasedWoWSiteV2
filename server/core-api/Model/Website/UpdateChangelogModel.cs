using System.ComponentModel.DataAnnotations;

namespace server.Model.Website
{
    public class UpdateChangelogModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public byte Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }
}

