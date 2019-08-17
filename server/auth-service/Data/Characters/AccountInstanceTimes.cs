using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class AccountInstanceTimes
    {
        public int AccountId { get; set; }
        public int InstanceId { get; set; }
        public long ReleaseTime { get; set; }
    }
}
