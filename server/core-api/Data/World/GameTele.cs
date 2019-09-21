using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class GameTele
    {
        public int Id { get; set; }
        public float PositionX { get; set; }
        public float PositionY { get; set; }
        public float PositionZ { get; set; }
        public float Orientation { get; set; }
        public short Map { get; set; }
        public string Name { get; set; }
    }
}
