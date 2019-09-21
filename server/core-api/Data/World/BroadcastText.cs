using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class BroadcastText
    {
        public int Id { get; set; }
        public int Language { get; set; }
        public string MaleText { get; set; }
        public string FemaleText { get; set; }
        public int EmoteId0 { get; set; }
        public int EmoteId1 { get; set; }
        public int EmoteId2 { get; set; }
        public int EmoteDelay0 { get; set; }
        public int EmoteDelay1 { get; set; }
        public int EmoteDelay2 { get; set; }
        public int SoundId { get; set; }
        public int Unk1 { get; set; }
        public int Unk2 { get; set; }
        
    }
}
