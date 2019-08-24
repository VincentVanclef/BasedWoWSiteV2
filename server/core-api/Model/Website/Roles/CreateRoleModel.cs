using System.ComponentModel.DataAnnotations;

namespace server.Model.Website.Roles
{
    public class CreateRoleModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
