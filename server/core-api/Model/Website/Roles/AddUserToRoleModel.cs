using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.Model.Website.Roles
{
    public class AddUserToRoleModel
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public List<string> Roles { get; set; }
    }
}
