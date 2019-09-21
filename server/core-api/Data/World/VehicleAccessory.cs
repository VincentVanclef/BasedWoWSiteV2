using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class VehicleAccessory
    {
        public int Guid { get; set; }
        public int AccessoryEntry { get; set; }
        public byte SeatId { get; set; }
        public byte Minion { get; set; }
        public string Description { get; set; }
        public byte Summontype { get; set; }
        public int Summontimer { get; set; }
    }
}
