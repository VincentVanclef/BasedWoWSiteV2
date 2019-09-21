using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class GameobjectTemplateLocale
    {
        public int Entry { get; set; }
        public string Locale { get; set; }
        public string Name { get; set; }
        public string CastBarCaption { get; set; }
        public short? VerifiedBuild { get; set; }
    }
}
