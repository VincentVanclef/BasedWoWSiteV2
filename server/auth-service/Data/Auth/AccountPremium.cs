using System;
using System.Collections.Generic;

namespace server.Context
{
    public partial class AccountPremium
    {
        public int Account { get; set; }
        public long? Duration { get; set; }
        public string Comment { get; set; }
    }
}
