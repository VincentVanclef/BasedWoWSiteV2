using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class QuestOfferRewardLocale
    {
        public int Id { get; set; }
        public string Locale { get; set; }
        public string RewardText { get; set; }
        public short VerifiedBuild { get; set; }
    }
}
