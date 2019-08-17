using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class QuestTracker
    {
        public int Id { get; set; }
        public int CharacterGuid { get; set; }
        public DateTime QuestAcceptTime { get; set; }
        public DateTime? QuestCompleteTime { get; set; }
        public DateTime? QuestAbandonTime { get; set; }
        public byte CompletedByGm { get; set; }
        public string CoreHash { get; set; }
        public string CoreRevision { get; set; }
    }
}
