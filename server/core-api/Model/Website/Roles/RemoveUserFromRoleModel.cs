using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.Model.Website.Roles
{
    public class RemoveUserFromRoleModel
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string RoleName { get; set; }
    }
}
