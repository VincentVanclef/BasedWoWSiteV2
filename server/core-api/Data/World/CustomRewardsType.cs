using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class CustomRewardsType
    {
        public CustomRewardsType()
        {
            CustomRewards = new HashSet<CustomRewards>();
        }

        public byte Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<CustomRewards> CustomRewards { get; set; }
    }
}
