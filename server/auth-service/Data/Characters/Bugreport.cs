using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class Bugreport
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
    }
}
