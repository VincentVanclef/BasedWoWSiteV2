using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class ItemSetNamesLocale
    {
        public int Id { get; set; }
        public string Locale { get; set; }
        public string Name { get; set; }
        public short? VerifiedBuild { get; set; }
    }
}
