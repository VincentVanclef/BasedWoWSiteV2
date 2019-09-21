using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class ScriptSplineChainWaypoints
    {
        public int Entry { get; set; }
        public short ChainId { get; set; }
        public byte SplineId { get; set; }
        public byte WpId { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
    }
}
