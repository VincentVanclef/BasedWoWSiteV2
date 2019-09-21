using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class CreatureTemplateLocale
    {
        public int Entry { get; set; }
        public string Locale { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public short? VerifiedBuild { get; set; }
    }
}
