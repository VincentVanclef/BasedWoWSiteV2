using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.ApiExtensions;
using server.Data.Website;
using server.Model.Website.Roles;

namespace server.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RoleController(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet("GetRoles")]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _roleManager.Roles.Select(x => new
            {
                x.Id,
                x.Name
            }).ToListAsync();

            return Ok(roles);
        }

        [HttpGet("GetUsersInRole/{role}")]
        public async Task<IActionResult> GetUsersInRole(string role)
        {
            var result = await _userManager.GetUsersInRoleAsync(role);
            return Ok(result);
        }

        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleModel model)
        {
            var result = await _roleManager.CreateAsync(new ApplicationRole(model.RoleName));
            if (!result.Succeeded)
                return RequestHandler.BadRequest(result.Errors);

            return Ok();
        }

        [HttpPost("DeleteRole")]
        public async Task<IActionResult> DeleteRole([FromBody] DeleteRoleModel model)
        {
            var role = await _roleManager.FindByNameAsync(model.RoleName);
            if (role == null)
                return RequestHandler.BadRequest($"Role {model.RoleName} does not exists");

            var result = await _roleManager.DeleteAsync(role);
            if (!result.Succeeded)
                return RequestHandler.BadRequest(result.Errors);

            return Ok();
        }

        [HttpPost("AddUserToRole")]
        public async Task<IActionResult> AddUserToRule([FromBody] AddUserToRoleModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId.ToString());
            if (user == null)
                return RequestHandler.UserNotFound();

            var result = await _userManager.AddToRoleAsync(user, model.RoleName);
            if (!result.Succeeded)
                return RequestHandler.BadRequest(result.Errors);

            return Ok();
        }

        [HttpPost("RemoveUserFromRole")]
        public async Task<IActionResult> RemoveUserFromRole([FromBody] RemoveUserFromRoleModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId.ToString());
            if (user == null)
                return RequestHandler.UserNotFound();

            var result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);
            if (!result.Succeeded)
                return RequestHandler.BadRequest(result.Errors);

            return Ok();
        }
    }
}