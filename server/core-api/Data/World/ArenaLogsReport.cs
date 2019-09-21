using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class ArenaLogsReport
    {
        public int Id { get; set; }
        public int WinnerTeamId { get; set; }
        public int LoserTeamId { get; set; }
        public DateTime Time { get; set; }
        public string Reason { get; set; }
    }
}
