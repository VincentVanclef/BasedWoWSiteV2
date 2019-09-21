using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class SkillPerfectItemTemplate
    {
        public int SpellId { get; set; }
        public int RequiredSpecialization { get; set; }
        public float PerfectCreateChance { get; set; }
        public int PerfectItemType { get; set; }
    }
}
