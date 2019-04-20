using System;
using System.Collections.Generic;

namespace server.Context
{
    public partial class RbacLinkedPermissionsOld
    {
        public int Id { get; set; }
        public int LinkedId { get; set; }

        public virtual RbacPermissionsOld IdNavigation { get; set; }
        public virtual RbacPermissionsOld Linked { get; set; }
    }
}
