using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class GameobjectTemplateAddon
    {
        public int Entry { get; set; }
        public short Faction { get; set; }
        public int Flags { get; set; }
        public int Mingold { get; set; }
        public int Maxgold { get; set; }
    }
}
