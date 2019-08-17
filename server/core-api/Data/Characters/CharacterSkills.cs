using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class CharacterSkills
    {
        public int Guid { get; set; }
        public short Skill { get; set; }
        public short Value { get; set; }
        public short Max { get; set; }
    }
}
