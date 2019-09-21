using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class SpellTargetPosition
    {
        public int Id { get; set; }
        public byte EffectIndex { get; set; }
        public short MapId { get; set; }
        public float PositionX { get; set; }
        public float PositionY { get; set; }
        public float PositionZ { get; set; }
        public float Orientation { get; set; }
        public short? VerifiedBuild { get; set; }
    }
}
