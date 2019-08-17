using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class CustomTransmogrificationSets
    {
        public int Owner { get; set; }
        public byte PresetId { get; set; }
        public string SetName { get; set; }
        public string SetData { get; set; }
    }
}
