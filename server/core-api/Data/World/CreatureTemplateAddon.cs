using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class CreatureTemplateAddon
    {
        public int Entry { get; set; }
        public int PathId { get; set; }
        public int Mount { get; set; }
        public int Bytes1 { get; set; }
        public int Bytes2 { get; set; }
        public int Emote { get; set; }
        public byte VisibilityDistanceType { get; set; }
        public string Auras { get; set; }
    }
}
