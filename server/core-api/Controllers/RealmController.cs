using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Context;
using server.Model;
using server.Services.Context;
using server.Util.Enums;

namespace server.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class RealmController : ControllerBase
    {
        private readonly AuthContext _authContext;
        private readonly IContextService _contextService;

        public RealmController(AuthContext authContext, IContextService contextService)
        {
            _authContext = authContext;
            _contextService = contextService;
        }

        [HttpGet("GetRealmInformations")]
        public async Task<IActionResult> GetRealmInformations()
        {
            var realms = await _authContext
                .Realmlist
                .Select(x => new RealmModel
                {
                   Id = x.Id,
                   Name = x.Name,
                   Online = (x.Flag & (byte)RealmFlags.Offline) != (byte)RealmFlags.Offline,
                   AllowedSecurityLevel = x.AllowedSecurityLevel,
                   Timezone = x.Timezone,
                }).ToListAsync();

            foreach (var realm in realms)
            {
                var context = _contextService.GetCharacterContext((RealmType)realm.Id);
                var players = await context
                    .Characters
                    .Where(x => x.IsOnline())
                    .Select(x => new PlayerModel
                    {
                        RealmId = realm.Id,
                        Name = x.Name,
                        Race = x.Race,
                        Class = x.Class,
                        Level = x.Level,
                        Zone = x.Zone,
                        Gender = x.Gender,
                        Rank = 0,
                        AccountId = x.Account
                    }).ToListAsync();

                foreach (var player in players)
                {
                    var rank = await _authContext.AccountAccess.Where(x => x.AccountId == player.AccountId && x.RealmId == realm.Id).Select(x => x.Gmlevel).FirstOrDefaultAsync();
                    player.Rank = rank;
                }

                realm.OnlinePlayers = players;
            }

            return Ok(realms);
        }
    }
}