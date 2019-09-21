using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class ZombieDeathmatchRounds
    {
        public byte Round { get; set; }
        public int ZombieEntry { get; set; }
        public int BaseCount { get; set; }
    }
}
