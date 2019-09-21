using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class QuestRequestItemsLocale
    {
        public int Id { get; set; }
        public string Locale { get; set; }
        public string CompletionText { get; set; }
        public short VerifiedBuild { get; set; }
    }
}
