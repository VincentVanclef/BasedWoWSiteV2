using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class AchievementCriteriaData
    {
        public int CriteriaId { get; set; }
        public byte Type { get; set; }
        public int Value1 { get; set; }
        public int Value2 { get; set; }
        public string ScriptName { get; set; }
    }
}
