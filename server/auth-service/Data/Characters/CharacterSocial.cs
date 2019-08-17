using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class CharacterSocial
    {
        public int Guid { get; set; }
        public int Friend { get; set; }
        public byte Flags { get; set; }
        public string Note { get; set; }
    }
}
