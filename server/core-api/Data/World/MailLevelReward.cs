using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class MailLevelReward
    {
        public byte Level { get; set; }
        public int RaceMask { get; set; }
        public int MailTemplateId { get; set; }
        public int SenderEntry { get; set; }
    }
}
