using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class AchievementRewardLocale
    {
        public int Id { get; set; }
        public string Locale { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
