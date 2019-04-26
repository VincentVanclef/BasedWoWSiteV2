using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Model.DTO
{
    public class UpdateUserDTO
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Location { get; set; }
    }
}
