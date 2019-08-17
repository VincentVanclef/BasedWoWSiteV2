using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Model.Website
{
    public class NewNewsModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public Guid Author { get; set; }
    }
}
