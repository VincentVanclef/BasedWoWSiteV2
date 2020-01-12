using System;

namespace server.Data.Website
{
    public class GamePatches
    {
        public string Patch { get; set; }
        public DateTime Modified { get; set; }
        public byte KeepUpdated { get; set; }
        public string Details { get; set; }
    }
}
