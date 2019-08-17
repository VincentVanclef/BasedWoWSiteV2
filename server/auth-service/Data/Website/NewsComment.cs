using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace server.Data.Website
{
    public class NewsComment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int NewsId { get; set; }
        public Guid UserId { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }

        [NotMapped]
        public string UserName { get; set; }
    }
}
