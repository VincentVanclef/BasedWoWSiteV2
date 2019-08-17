using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class Petition
    {
        public int Ownerguid { get; set; }
        public int? Petitionguid { get; set; }
        public string Name { get; set; }
        public byte Type { get; set; }
    }
}
