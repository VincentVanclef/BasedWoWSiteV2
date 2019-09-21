using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class ConfigInt
    {
        public int Id { get; set; }
        public string Config { get; set; }
        public int Value { get; set; }
        public string Comment { get; set; }
    }
}
