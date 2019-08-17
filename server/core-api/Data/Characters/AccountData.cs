using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class AccountData
    {
        public int AccountId { get; set; }
        public byte Type { get; set; }
        public int Time { get; set; }
        public byte[] Data { get; set; }
    }
}
