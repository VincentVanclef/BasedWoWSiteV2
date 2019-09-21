using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class PlayerhouseMembers
    {
        public int HouseId { get; set; }
        public int MemberGuid { get; set; }
        public int Permissions { get; set; }
    }
}
