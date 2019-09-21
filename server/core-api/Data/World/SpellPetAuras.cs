using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class SpellPetAuras
    {
        public int Spell { get; set; }
        public byte EffectId { get; set; }
        public int Pet { get; set; }
        public int Aura { get; set; }
    }
}
