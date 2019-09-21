using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class Command
    {
        public string Name { get; set; }
        public short Permission { get; set; }
        public string Help { get; set; }
    }
}
