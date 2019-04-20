using System;
using System.Collections.Generic;

namespace server.Context
{
    public partial class AccountAccess
    {
        public int Id { get; set; }
        public byte Gmlevel { get; set; }
        public int RealmId { get; set; }
    }
}
