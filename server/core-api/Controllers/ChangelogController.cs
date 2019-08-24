using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.ApiExtensions;
using server.Context;
using server.Data.Website;
using server.Model.Website;
using server.Util;

namespace server.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ChangelogController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly WebsiteContext _websiteContext;
        private readonly UserPermissions _userPermissions;

        public ChangelogController(UserManager<ApplicationUser> userManager, WebsiteContext websiteContext, UserPermissions userPermissions)
        {
            _websiteContext = websiteContext;
            _userManager = userManager;
            _userPermissions = userPermissions;
        }

        [HttpGet("GetAllChanges")]
        public async Task<IActionResult> GetAllChanges()
        {
            var result = await _websiteContext.Changelogs.OrderByDescending(o => o.Id).ToListAsync();
            return Ok(result);
        }

        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await _websiteContext.ChangelogCategories.OrderBy(o => o.Id).ToListAsync();
            return Ok(result);
        }

        [Authorize(Roles = "Admin, Moderator")]
        [HttpPost("AddNewChangelog")]
        public async Task<IActionResult> AddNewChangelog([FromBody] NewChangelogEntryModel model)
        {
            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return RequestHandler.Unauthorized();

            var category = await _websiteContext.ChangelogCategories.AnyAsync(x => x.Id == model.Category);
            if (!category)
                return RequestHandler.BadRequest($"No category with id {model.Category} exists");

            var newChange = new Changelog
            {
                CategoryId = model.Category,
                Title = model.Title,
                Realm = model.Realm,
                Content = model.Content
            };

            await _websiteContext.Changelogs.AddAsync(newChange);
            await _websiteContext.SaveChangesAsync();

            return Ok(new { NewId = newChange.Id });
        }

        [Authorize(Roles = "Admin, Moderator")]
        [HttpPost("AddNewCategory")]
        public async Task<IActionResult> AddNewCategory([FromBody] NewChangelogCategoryEntryModel model)
        {
            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return RequestHandler.Unauthorized();

            var newCategory = new ChangelogCategory
            {
                Title = model.Title,
                Color = model.Color
            };

            await _websiteContext.ChangelogCategories.AddAsync(newCategory);
            await _websiteContext.SaveChangesAsync();

            return Ok(new { NewId = newCategory.Id });
        }

        [Authorize(Roles = "Admin, Moderator")]
        [HttpPost("DeleteChangelog")]
        public async Task<IActionResult> DeleteChangelog([FromBody] IdEntryModel model)
        {
            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return RequestHandler.Unauthorized();

            var changelog = await _websiteContext.Changelogs.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (changelog == null)
                return RequestHandler.BadRequest($"No changelog with id {model.Id} exists");

            _websiteContext.Changelogs.Remove(changelog);
            await _websiteContext.SaveChangesAsync();

            return Ok();
        }

        [Authorize(Roles = "Admin, Moderator")]
        [HttpPost("DeleteChangelogCategory")]
        public async Task<IActionResult> DeleteChangelogCategory([FromBody] IdEntryModel model)
        {
            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return RequestHandler.Unauthorized();

            var changelogCategory = await _websiteContext.ChangelogCategories.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (changelogCategory == null)
                return RequestHandler.BadRequest($"No changelog category with id {model.Id} exists");

            var result = await _websiteContext.Changelogs.CountAsync(x => x.CategoryId == model.Id);
            if (result > 0)
                return RequestHandler.BadRequest($"There are {result} changes that uses this category, please remove them or change their category.");

            _websiteContext.ChangelogCategories.Remove(changelogCategory);
            await _websiteContext.SaveChangesAsync();

            return Ok();
        }

        [Authorize(Roles = "Admin, Moderator")]
        [HttpPost("UpdateChangelog")]
        public async Task<IActionResult> UpdateChangelog([FromBody] UpdateChangelogModel model)
        {
            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return RequestHandler.Unauthorized();

            var changelog = await _websiteContext.Changelogs.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (changelog == null)
                return RequestHandler.BadRequest($"No changelog with id {model.Id} exists");

            changelog.Content = model.Content;
            changelog.Title = model.Title;
            changelog.CategoryId = model.Category;

            await _websiteContext.SaveChangesAsync();

            return Ok();
        }
    }
}