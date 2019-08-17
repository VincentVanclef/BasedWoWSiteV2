using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class CharacterInstance
    {
        public int Guid { get; set; }
        public int Instance { get; set; }
        public byte Permanent { get; set; }
        public byte ExtendState { get; set; }
    }
}
