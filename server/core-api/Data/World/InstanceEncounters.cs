using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class InstanceEncounters
    {
        public int Entry { get; set; }
        public byte CreditType { get; set; }
        public int CreditEntry { get; set; }
        public short LastEncounterDungeon { get; set; }
        public string Comment { get; set; }
    }
}
