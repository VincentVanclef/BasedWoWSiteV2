using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class Instance
    {
        public int Id { get; set; }
        public short Map { get; set; }
        public long Resettime { get; set; }
        public byte Difficulty { get; set; }
        public int CompletedEncounters { get; set; }
        public string Data { get; set; }
    }
}
