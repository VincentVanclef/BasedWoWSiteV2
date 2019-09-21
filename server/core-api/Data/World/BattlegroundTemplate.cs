using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class BattlegroundTemplate
    {
        public int Id { get; set; }
        public short MinPlayersPerTeam { get; set; }
        public short MaxPlayersPerTeam { get; set; }
        public byte MinLvl { get; set; }
        public byte MaxLvl { get; set; }
        public int AllianceStartLoc { get; set; }
        public float AllianceStartO { get; set; }
        public int HordeStartLoc { get; set; }
        public float HordeStartO { get; set; }
        public float StartMaxDist { get; set; }
        public byte Weight { get; set; }
        public string ScriptName { get; set; }
        public string Comment { get; set; }
    }
}
