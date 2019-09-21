using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class CustomConditions
    {
        public int Id { get; set; }
        public int CondReqType { get; set; }
        public int CondReqEntry { get; set; }
        public int CondReqValue { get; set; }
        public string Note { get; set; }

        public virtual CustomConditionInfo CondReqTypeNavigation { get; set; }
    }
}
