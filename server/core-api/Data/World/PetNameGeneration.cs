using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class PetNameGeneration
    {
        public int Id { get; set; }
        public string Word { get; set; }
        public int Entry { get; set; }
        public byte Half { get; set; }
    }
}
