using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class QuestRequestItems
    {
        public int Id { get; set; }
        public short EmoteOnComplete { get; set; }
        public short EmoteOnIncomplete { get; set; }
        public string CompletionText { get; set; }
        public short VerifiedBuild { get; set; }
    }
}
