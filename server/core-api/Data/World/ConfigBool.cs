using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class ConfigBool
    {
        public int Id { get; set; }
        public string Config { get; set; }
        public byte Value { get; set; }
        public string Comment { get; set; }
    }
}
