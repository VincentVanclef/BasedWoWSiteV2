using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class CharacterCurrencies
    {
        public long Guid { get; set; }
        public byte WinStreak { get; set; }
        public byte TopWinStreak { get; set; }
        public float? RankPoints { get; set; }
        public float? TopRankPoints { get; set; }
        public long DailyQuestTimer { get; set; }
        public byte DailyQuestAmount { get; set; }
        public int KillingSpree { get; set; }
        public short TotalUpgradeRank { get; set; }
        public int BattleRoyaleWins { get; set; }
        public int BattleRoyaleTotal { get; set; }
        public int LastManStandingWins { get; set; }
        public int LastManStandingTotal { get; set; }
        public int KingOfTheHillStreak { get; set; }
        public byte ShowGuildLevel { get; set; }
    }
}
