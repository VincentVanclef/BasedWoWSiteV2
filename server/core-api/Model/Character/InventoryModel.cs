using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Data.World;

namespace server.Model.Character
{
    public class InventoryModel
    {
        public int ItemEntry { get; set; }
        public int ItemCount { get; set; }
        public ItemTemplate Item { get; set; }
    }
}
