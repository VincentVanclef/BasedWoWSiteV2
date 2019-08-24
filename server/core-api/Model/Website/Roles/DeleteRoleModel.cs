using System.ComponentModel.DataAnnotations;

namespace server.Model.Website.Roles
{
    public class DeleteRoleModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
