using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class GroupMember
    {
        public int Guid { get; set; }
        public int MemberGuid { get; set; }
        public byte MemberFlags { get; set; }
        public byte Subgroup { get; set; }
        public byte Roles { get; set; }
    }
}
