using System.ComponentModel.DataAnnotations;

namespace server.Model.Website
{
    public class NewChangelogCategoryEntryModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Color { get; set; }
    }
}
