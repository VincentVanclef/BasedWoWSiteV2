using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class CharacterGifts
    {
        public int Guid { get; set; }
        public int ItemGuid { get; set; }
        public int Entry { get; set; }
        public int Flags { get; set; }
    }
}
