using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class CharacterGlyphs
    {
        public int Guid { get; set; }
        public byte TalentGroup { get; set; }
        public short? Glyph1 { get; set; }
        public short? Glyph2 { get; set; }
        public short? Glyph3 { get; set; }
        public short? Glyph4 { get; set; }
        public short? Glyph5 { get; set; }
        public short? Glyph6 { get; set; }
    }
}
