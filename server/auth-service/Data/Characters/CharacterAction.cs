using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class CharacterAction
    {
        public int Guid { get; set; }
        public byte Spec { get; set; }
        public byte Button { get; set; }
        public int Action { get; set; }
        public byte Type { get; set; }
    }
}
