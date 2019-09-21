using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class Creature
    {
        public int Guid { get; set; }
        public int Id { get; set; }
        public short Map { get; set; }
        public short ZoneId { get; set; }
        public short AreaId { get; set; }
        public byte SpawnMask { get; set; }
        public int PhaseMask { get; set; }
        public int Modelid { get; set; }
        public byte EquipmentId { get; set; }
        public float PositionX { get; set; }
        public float PositionY { get; set; }
        public float PositionZ { get; set; }
        public float Orientation { get; set; }
        public int Spawntimesecs { get; set; }
        public float Spawndist { get; set; }
        public int Currentwaypoint { get; set; }
        public int Curhealth { get; set; }
        public int Curmana { get; set; }
        public byte MovementType { get; set; }
        public int Npcflag { get; set; }
        public int UnitFlags { get; set; }
        public int Dynamicflags { get; set; }
        public string ScriptName { get; set; }
        public short? VerifiedBuild { get; set; }
        public float Size { get; set; }
    }
}
