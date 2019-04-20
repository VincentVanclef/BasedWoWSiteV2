using System;
using System.Collections.Generic;

namespace server.Context
{
    public partial class AccountMuted
    {
        public int Guid { get; set; }
        public int Mutedate { get; set; }
        public int Mutetime { get; set; }
        public string Mutedby { get; set; }
        public string Mutereason { get; set; }
    }
}
