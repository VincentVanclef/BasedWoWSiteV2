﻿using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class CustomNoFlyAreas
    {
        public int AreaId { get; set; }
        public long? Duration { get; set; }
        public string Comment { get; set; }
    }
}
