using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class ArenaTeamMember
    {
        public int ArenaTeamId { get; set; }
        public int Guid { get; set; }
        public short WeekGames { get; set; }
        public short WeekWins { get; set; }
        public short SeasonGames { get; set; }
        public short SeasonWins { get; set; }
        public short PersonalRating { get; set; }
    }
}
