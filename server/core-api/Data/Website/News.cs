using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace server.Data.Website
{
    public class News
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid Author { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }

        [NotMapped]
        public string AuthorName { get; set; }

        public virtual List<NewsComment> Comments { get; set; }
    }
}
