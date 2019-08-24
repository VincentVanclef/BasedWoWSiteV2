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

            var result = await context.Characters.Where(x => x.IsOnline()).Select(x => x.Race).ToListAsync();

            var allianceOnline = 0;
            var hordeOnline = 0;

            foreach (var playerRace in result)
            {
                switch (playerRace)
                {
                    case 2:
                    case 5:
                    case 6:
                    case 8:
                    case 9:
                    case 10:
                        ++hordeOnline;
                        break;
                    case 1:
                    case 3:
                    case 4:
                    case 7:
                    case 11:
                        ++allianceOnline;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException($"Unknown race {playerRace} - Not supported");
                }
            }

            return Ok(new { aonline= allianceOnline, honline = hordeOnline });
        }

        [HttpPost("GetOnlinePlayersData")]
        public async Task<IActionResult> GetOnlinePlayersData([FromBody] RealmTypeModel model)
        {
            var context = _contextService.GetCharacterContext(model.RealmType);

            var result = await context.Characters.Where(x => x.IsOnline()).Select(x =>
                new
                {
                    x.Name,
                    x.Race,
                    x.Class,
                    x.Level,
                    x.Zone,
                    x.Gender
                }).ToListAsync();

            var allianceOnline = 0;
            var hordeOnline = 0;

            foreach (var player in result)
            {
                switch (player.Race)
                {
                    case 2:
                    case 5:
                    case 6:
                    case 8:
                    case 9:
                    case 10:
                        ++hordeOnline;
                        break;
                    case 1:
                    case 3:
                    case 4:
                    case 7:
                    case 11:
                        ++allianceOnline;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException($"Unknown race {player.Race} - Not supported");
                }
            }

            return Ok(new { aonline = allianceOnline, honline = hordeOnline, result });
        }
    }
}