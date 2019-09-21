using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class SkillExtraItemTemplate
    {
        public int SpellId { get; set; }
        public int RequiredSpecialization { get; set; }
        public float AdditionalCreateChance { get; set; }
        public byte AdditionalMaxNum { get; set; }
    }
}
