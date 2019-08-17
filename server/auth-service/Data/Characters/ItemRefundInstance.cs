using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class ItemRefundInstance
    {
        public int ItemGuid { get; set; }
        public int PlayerGuid { get; set; }
        public int PaidMoney { get; set; }
        public short PaidExtendedCost { get; set; }
    }
}
