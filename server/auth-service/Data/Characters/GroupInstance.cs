using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class GroupInstance
    {
        public int Guid { get; set; }
        public int Instance { get; set; }
        public byte Permanent { get; set; }
    }
}
