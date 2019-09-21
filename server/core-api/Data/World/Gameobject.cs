using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class Gameobject
    {
        public int Guid { get; set; }
        public int Id { get; set; }
        public short Map { get; set; }
        public short ZoneId { get; set; }
        public short AreaId { get; set; }
        public byte SpawnMask { get; set; }
        public int PhaseMask { get; set; }
        public float PositionX { get; set; }
        public float PositionY { get; set; }
        public float PositionZ { get; set; }
        public float Orientation { get; set; }
        public float Rotation0 { get; set; }
        public float Rotation1 { get; set; }
        public float Rotation2 { get; set; }
        public float Rotation3 { get; set; }
        public int Spawntimesecs { get; set; }
        public byte Animprogress { get; set; }
        public byte State { get; set; }
        public string ScriptName { get; set; }
        public short? VerifiedBuild { get; set; }
        public float Size { get; set; }
    }
}
