using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class Playerhouses
    {
        public int HouseId { get; set; }
        public int OwnerGuid { get; set; }
        public int MapId { get; set; }
        public int AreaId { get; set; }
        public int ZoneId { get; set; }
        public float PosX { get; set; }
        public float PosY { get; set; }
        public float PosZ { get; set; }
        public float Length { get; set; }
        public float Height { get; set; }
        public int BuyPrice { get; set; }
        public string HouseName { get; set; }
        public byte MaxObjects { get; set; }
        public byte MaxNpcs { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
