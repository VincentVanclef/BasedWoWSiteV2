using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace server.Data.Website
{
    public class Changelog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public byte Realm { get; set; }
        public string Title { get; set; }
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
