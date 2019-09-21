using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class AchievementReward
    {
        public int Id { get; set; }
        public int TitleA { get; set; }
        public int TitleH { get; set; }
        public int ItemId { get; set; }
        public int Sender { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public int? MailTemplateId { get; set; }
    }
}
