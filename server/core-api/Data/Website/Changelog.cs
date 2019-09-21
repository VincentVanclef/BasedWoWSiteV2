using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using server.Model.Website;

namespace server.Data.Website
{
    public class Changelog : AuthorModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public byte Realm { get; set; }
        public string Content { get; set; }
        public byte CategoryId { get; set; }
        public DateTime Date { get; set; }
    }

    public class ChangelogCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Color { get; set; }
    }
}
