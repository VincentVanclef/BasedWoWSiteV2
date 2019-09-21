using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class PlayercreateinfoAction
    {
        public byte Race { get; set; }
        public byte Class { get; set; }
        public short Button { get; set; }
        public int Action { get; set; }
        public short Type { get; set; }
    }
}
