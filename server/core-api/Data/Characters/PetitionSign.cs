using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class PetitionSign
    {
        public int Ownerguid { get; set; }
        public int Petitionguid { get; set; }
        public int Playerguid { get; set; }
        public int PlayerAccount { get; set; }
        public byte Type { get; set; }
    }
}
