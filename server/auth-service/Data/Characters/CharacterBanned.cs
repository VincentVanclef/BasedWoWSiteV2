using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class CharacterBanned
    {
        public int Guid { get; set; }
        public int Bandate { get; set; }
        public int Unbandate { get; set; }
        public string Bannedby { get; set; }
        public string Banreason { get; set; }
        public byte Active { get; set; }
    }
}
