using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class InstanceTemplate
    {
        public short Map { get; set; }
        public short Parent { get; set; }
        public string Script { get; set; }
        public byte AllowMount { get; set; }
    }
}
