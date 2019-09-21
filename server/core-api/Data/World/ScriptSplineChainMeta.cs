using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class ScriptSplineChainMeta
    {
        public int Entry { get; set; }
        public short ChainId { get; set; }
        public byte SplineId { get; set; }
        public int ExpectedDuration { get; set; }
        public int MsUntilNext { get; set; }
        public float? Velocity { get; set; }
    }
}
