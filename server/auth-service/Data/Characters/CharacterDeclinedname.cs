using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class CharacterDeclinedname
    {
        public int Guid { get; set; }
        public string Genitive { get; set; }
        public string Dative { get; set; }
        public string Accusative { get; set; }
        public string Instrumental { get; set; }
        public string Prepositional { get; set; }
    }
}
