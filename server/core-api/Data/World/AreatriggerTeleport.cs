using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class AreatriggerTeleport
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short TargetMap { get; set; }
        public float TargetPositionX { get; set; }
        public float TargetPositionY { get; set; }
        public float TargetPositionZ { get; set; }
        public float TargetOrientation { get; set; }
        
    }
}
