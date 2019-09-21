using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Data.World;

namespace server.Model.World
{
    public class InventoryModel
    {
        public ItemTemplate Item { get; set; }
        public int Count { get; set; }
    }
}
