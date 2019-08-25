using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using server.Data.Website;
using server.Model.Character;
using server.Model.Character.ArenaTeam;
using server.Services;
using server.Services.SignalR;
using server.Util;

namespace server.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ContextService _contextService;
        private readonly IHubContext<SignalRHub> _hubContext;

        public StatisticsController(UserManager<ApplicationUser> userManager, ContextService contextService, IHubContext<SignalRHub> hubContext)
        {
            _userManager = userManager;
            _contextService = contextService;
            _hubContext = hubContext;
        }

        [HttpPost("GetTopArenaTeams")]
        public async Task<IActionResult> GetTopArenaTeams([FromBody] SelectTopArenaTeamsModel model)
        {
            var limit = model.Limit.EnsureMinValue();

            var context = _contextService.GetCharacterContext(model.RealmType);

            var result = await context.ArenaTeam
                     .Where(x => x.Type == 2)
                     .Select(x => new
                     {
                         Name = x.Name,
                         ArenaTeamId = x.ArenaTeamId,
                         Rating = x.Rating,
                         Rank = x.Rank,
                         Captain = x.CaptainGuid,
                         Type = x.Type
                     }).OrderByDescending(o => o.Rating).Take(limit)
                .Union(context.ArenaTeam
                    .Where(x => x.Type == 3)
                    .Select(x => new
                    {
                        Name = x.Name,
                        ArenaTeamId = x.ArenaTeamId,
                        Rating = x.Rating,
                        Rank = x.Rank,
                        Captain = x.CaptainGuid,
                        Type = x.Type
                    })
                    .OrderByDescending(o => o.Rating).Take(limit))
                .Union(context.ArenaTeam
                    .Where(x => x.Type == 5)
                    .Select(x => new
                    {
                        Name = x.Name,
                        ArenaTeamId = x.ArenaTeamId,
                        Rating = x.Rating,
                        Rank = x.Rank,
                        Captain = x.CaptainGuid,
                        Type = x.Type
                    }).OrderByDescending(o => o.Rating).Take(limit)).ToListAsync();

            return Ok(result);
        }

        [HttpPost("GetTopArenaTeamMembers")]
        public async Task<IActionResult> GetTopArenaTeamMembers([FromBody] SelectArenaTeamMembersModel model)
        {
            var context = _contextService.GetCharacterContext(model.RealmType); ;

            var result = await (context.ArenaTeamMember
                .Join(context.Characters, c => c.Guid, a => a.Guid, (a, c) => new { a, c })
                .Where(x => model.Teams.Contains(x.a.ArenaTeamId))
                .Select(x => new
                {
                    ArenaTeamId = x.a.ArenaTeamId,
                    Guid = x.a.Guid,
                    Rating = x.a.PersonalRating,
                    Games = x.a.SeasonGames,
                    Wins = x.a.SeasonWins,
                    Name = x.c.Name,
                    Class = x.c.Class,
                    Level = x.c.Level
                }).OrderBy(o => o.Guid)).ToListAsync();

            return Ok(result);
        }

        [HttpPost("GetTopHKPlayers")]
        public async Task<IActionResult> GetTopHKPlayers([FromBody] SelectTopHKModel model)
        {
            var limit = model.Limit.EnsureMinValue();

            var context = _contextService.GetCharacterContext(model.RealmType);

            var result = (await context.Characters
                .Where(x => x.TotalKills > 0)
                .Select(x => new TopHKPlayerStatistic
                {
                    Guid = x.Guid,
                    Name = x.Name,
                    Level = x.Level,
                    Race = x.Race,
                    Class = x.Class,
                    Gender = x.Gender,
                    Kills = x.TotalKills
                })
                .OrderByDescending(o => o.Kills)
                .Take(limit)
                .ToListAsync())
                .Select((d, index) => new TopHKPlayerStatistic(d, index + 1))
                .ToList();

            return Ok(result);
        }
    }
}