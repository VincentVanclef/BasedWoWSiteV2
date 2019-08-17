using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Data.Website
{
    public class UnstuckLocation
    {
        public int Id { get; set; }
        public byte RealmId { get; set; }
        public float PositionX { get; set; }
        public float PositionY { get; set; }
        public float PositionZ { get; set; }
        public short Map { get; set; }
        public string Name { get; set; }
    }
}
