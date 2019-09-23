using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.Data.Website
{
    public class ItemDisplayInfo
    {
        [Key]
        public int Id { get; set; }
        public string Icon { get; set; }
    }
}
