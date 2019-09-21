using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class GameEventModelEquip
    {
        public byte EventEntry { get; set; }
        public int Guid { get; set; }
        public int Modelid { get; set; }
        public byte EquipmentId { get; set; }
    }
}
