using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class CreatureTextLocale
    {
        public int CreatureId { get; set; }
        public byte GroupId { get; set; }
        public byte Id { get; set; }
        public string Locale { get; set; }
        public string Text { get; set; }
    }
}
