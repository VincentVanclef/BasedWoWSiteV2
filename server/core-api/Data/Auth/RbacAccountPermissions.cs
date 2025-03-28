﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Data.Auth
{
    public class RbacAccountPermissions
    {
        public int AccountId { get; set; }
        public int PermissionId { get; set; }
        public byte Granted { get; set; }
        public int RealmId { get; set; }

        public virtual Account Account { get; set; }
        public virtual RbacPermissions Permission { get; set; }
    }
}
