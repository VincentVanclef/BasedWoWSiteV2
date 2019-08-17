using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class PetAura
    {
        public int Guid { get; set; }
        public long CasterGuid { get; set; }
        public int Spell { get; set; }
        public byte EffectMask { get; set; }
        public byte RecalculateMask { get; set; }
        public byte StackCount { get; set; }
        public int Amount0 { get; set; }
        public int Amount1 { get; set; }
        public int Amount2 { get; set; }
        public int BaseAmount0 { get; set; }
        public int BaseAmount1 { get; set; }
        public int BaseAmount2 { get; set; }
        public int MaxDuration { get; set; }
        public int RemainTime { get; set; }
        public byte RemainCharges { get; set; }
        public float CritChance { get; set; }
        public byte ApplyResilience { get; set; }
    }
}
