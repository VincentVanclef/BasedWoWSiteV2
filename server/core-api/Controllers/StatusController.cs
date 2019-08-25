using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Model;
using server.Services;

namespace server.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly ContextService _contextService;

        public StatusController(ContextService contextService)
        {
            _contextService = contextService;
        }

        [HttpPost("GetOnlinePlayers")]
        public async Task<IActionResult> GetOnlinePlayers([FromBody] RealmTypeModel model)
        {
            var context = _contextService.GetCharacterContext(model.RealmType);

            var result = await context.Characters
                .Where(x => x.IsOnline())
                .Select(x =>
                new PlayerModel
                {
                   Name = x.Name,
                   Race = x.Race,
                   Class = x.Class,
                   Level = x.Level,
                   Zone = x.Zone,
                   Gender = x.Gender
                }).ToListAsync();

            return Ok(result);
        }
    }
}