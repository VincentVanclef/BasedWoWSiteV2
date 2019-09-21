using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class BroadcastTextLocale
    {
        public int Id { get; set; }
        public string Locale { get; set; }
        public string MaleText { get; set; }
        public string FemaleText { get; set; }
        public short? VerifiedBuild { get; set; }
    }
}
