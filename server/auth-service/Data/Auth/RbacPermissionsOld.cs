using System;
using System.Collections.Generic;

namespace server.Context
{
    public partial class RbacPermissionsOld
    {
        public RbacPermissionsOld()
        {
            RbacLinkedPermissionsOldIdNavigation = new HashSet<RbacLinkedPermissionsOld>();
            RbacLinkedPermissionsOldLinked = new HashSet<RbacLinkedPermissionsOld>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RbacLinkedPermissionsOld> RbacLinkedPermissionsOldIdNavigation { get; set; }
        public virtual ICollection<RbacLinkedPermissionsOld> RbacLinkedPermissionsOldLinked { get; set; }
    }
}
