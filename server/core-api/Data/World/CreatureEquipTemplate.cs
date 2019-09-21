using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class CreatureEquipTemplate
    {
        public int CreatureId { get; set; }
        public byte Id { get; set; }
        public int ItemId1 { get; set; }
        public int ItemId2 { get; set; }
        public int ItemId3 { get; set; }
        public short? VerifiedBuild { get; set; }
    }
}
