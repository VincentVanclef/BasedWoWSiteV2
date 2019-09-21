using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class CustomTeleporter
    {
        public int Entry { get; set; }
        public int Map { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float O { get; set; }
        public byte Near { get; set; }
    }
}
