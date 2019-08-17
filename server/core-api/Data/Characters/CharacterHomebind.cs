using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class CharacterHomebind
    {
        public int Guid { get; set; }
        public short MapId { get; set; }
        public short ZoneId { get; set; }
        public float PosX { get; set; }
        public float PosY { get; set; }
        public float PosZ { get; set; }
    }
}
