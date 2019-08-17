using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class PvpstatsPlayers
    {
        public long BattlegroundId { get; set; }
        public int CharacterGuid { get; set; }
        public int Winner { get; set; }
        public int ScoreKillingBlows { get; set; }
        public int ScoreDeaths { get; set; }
        public int ScoreHonorableKills { get; set; }
        public int ScoreBonusHonor { get; set; }
        public int ScoreDamageDone { get; set; }
        public int ScoreHealingDone { get; set; }
        public int Attr1 { get; set; }
        public int Attr2 { get; set; }
        public int Attr3 { get; set; }
        public int Attr4 { get; set; }
        public int Attr5 { get; set; }
    }
}
