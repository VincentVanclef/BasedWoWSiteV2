using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class CustomConditionInfo
    {
        public CustomConditionInfo()
        {
            CustomConditions = new HashSet<CustomConditions>();
        }

        public int ConditionType { get; set; }
        public string ConditionInformation { get; set; }

        public virtual ICollection<CustomConditions> CustomConditions { get; set; }
    }
}
