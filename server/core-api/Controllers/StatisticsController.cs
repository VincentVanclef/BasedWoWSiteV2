using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using server.Context;
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
        private readonly AuthContext _authContext;
        private readonly IHubContext<SignalRHub> _hubContext;

        public StatisticsController(UserManager<ApplicationUser> userManager, ContextService contextService, AuthContext authContext, IHubContext<SignalRHub> hubContext)
        {
            _userManager = userManager;
            _contextService = contextService;
            _authContext = authContext;
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
                .Join(context.Characters, c => c.Guid, a => a.Id, (a, c) => new { a, c })
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
                    Guid = x.Id,
                    Name = x.Name,
                    Level = x.Level,
                    Race = x.Race,
                    Class = x.Class,
                    Gender = x.Gender,
                    Kills = x.TotalKills,
                    AccountId = x.Account
                })
                .OrderByDescending(o => o.Kills)
                .Take(limit)
                .ToListAsync())
                .Select((d, index) => new TopHKPlayerStatistic(d, index + 1))
                .ToList();

            return Ok(result);
        }

        [HttpGet("GetOnlineUsers")]
        public async Task<IActionResult> GetOnlineUsers()
        {
            return Ok(await _userManager.Users.CountAsync(x => x.IsOnline()));
        }


        [HttpGet("GetTotalAccounts")]
        public async Task<IActionResult> GetTotalAccounts()
        {
            return Ok(await _authContext.Account.CountAsync());
        }

        [HttpGet("GetUserInformations")]
        public async Task<IActionResult> GetUserInformations()
        {
            var user = await _userManager.Users.OrderByDescending(o => o.JoinDate).FirstOrDefaultAsync();
            var count = await _userManager.Users.CountAsync();
            return Ok(new { user = user?.UserName, count });
        }

        [AllowAnonymous]
        [HttpGet("GetGameMasters")]
        public async Task<IActionResult> GetGameMasters()
        {
            var trials = await _authContext.Account
                .Where(x => x.AccountAccess.Any(a => a.Gmlevel == (byte)GameRoles.Trial)).ToListAsync();

            var gamemasters = await _authContext.Account
                .Where(x => x.AccountAccess.Any(a => a.Gmlevel == (byte)GameRoles.GameMaster)).ToListAsync();

            var admins = await _authContext.Account
                .Where(x => x.AccountAccess.Any(a => a.Gmlevel == (byte)GameRoles.Admin)).ToListAsync();

            return Ok(new { trials, gamemasters, admins });
        }
    }
}