using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class InstanceReset
    {
        public short Mapid { get; set; }
        public byte Difficulty { get; set; }
        public long Resettime { get; set; }
    }
}
