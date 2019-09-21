using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class QuestPoolTemplate
    {
        public int PoolId { get; set; }
        public int NumActive { get; set; }
        public string Description { get; set; }
    }
}
