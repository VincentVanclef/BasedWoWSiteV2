using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class PlayercreateinfoSkills
    {
        public int RaceMask { get; set; }
        public int ClassMask { get; set; }
        public short Skill { get; set; }
        public short Rank { get; set; }
        public string Comment { get; set; }
    }
}
