using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class Corpse
    {
        public int Guid { get; set; }
        public float PosX { get; set; }
        public float PosY { get; set; }
        public float PosZ { get; set; }
        public float Orientation { get; set; }
        public short MapId { get; set; }
        public int PhaseMask { get; set; }
        public int DisplayId { get; set; }
        public string ItemCache { get; set; }
        public int Bytes1 { get; set; }
        public int Bytes2 { get; set; }
        public int GuildId { get; set; }
        public byte Flags { get; set; }
        public byte DynFlags { get; set; }
        public int Time { get; set; }
        public byte CorpseType { get; set; }
        public int InstanceId { get; set; }
    }
}
