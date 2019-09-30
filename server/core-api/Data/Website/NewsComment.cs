using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using server.Model.Website;

namespace server.Data.Website
{
    public class NewsComment : AuthorModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Id { get; set; }
        public uint NewsId { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public DateTime? LastEdited { get; set; }
    }
}
