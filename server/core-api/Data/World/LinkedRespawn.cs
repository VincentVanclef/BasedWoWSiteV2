using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class LinkedRespawn
    {
        public int Guid { get; set; }
        public int LinkedGuid { get; set; }
        public byte LinkType { get; set; }
    }
}
