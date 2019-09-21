using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class GameobjectAddon
    {
        public int Guid { get; set; }
        public float ParentRotation0 { get; set; }
        public float ParentRotation1 { get; set; }
        public float ParentRotation2 { get; set; }
        public float ParentRotation3 { get; set; }
        public byte InvisibilityType { get; set; }
        public int InvisibilityValue { get; set; }
    }
}
