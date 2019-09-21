using System;
using System.ComponentModel.DataAnnotations;

namespace server.Model.Website
{
    public class NewChangelogEntryModel
    {
        [Required]
        public byte Realm { get; set; }

        [Required]
        public byte Category { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public Guid Author { get; set; }
    }
}
