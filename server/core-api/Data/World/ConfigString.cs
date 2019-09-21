using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class ConfigString
    {
        public int Id { get; set; }
        public string Config { get; set; }
        public string Value { get; set; }
        public string Comment { get; set; }
    }
}
