using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace server.Model.Website
{
    public class AuthorModel
    {
        public Guid Author { get; set; }
        [NotMapped]
        public string AuthorName { get; set; }
    }
}
