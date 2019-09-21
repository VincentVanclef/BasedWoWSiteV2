using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class SpellLearnSpell
    {
        public short Entry { get; set; }
        public short SpellId { get; set; }
        public byte Active { get; set; }
    }
}
