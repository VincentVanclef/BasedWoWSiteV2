using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class LagReports
    {
        public int ReportId { get; set; }
        public int Guid { get; set; }
        public byte LagType { get; set; }
        public short MapId { get; set; }
        public float PosX { get; set; }
        public float PosY { get; set; }
        public float PosZ { get; set; }
        public int Latency { get; set; }
        public int CreateTime { get; set; }
    }
}
