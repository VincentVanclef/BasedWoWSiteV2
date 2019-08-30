using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Context;
using server.Model;
using server.Services;
using server.Util;

namespace server.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class RealmController : ControllerBase
    {
        private readonly AuthContext _authContext;
        private readonly ContextService _contextService;
        private readonly UserPermissions _userPermissions;

        public RealmController(AuthContext authContext, ContextService contextService, UserPermissions userPermissions)
        {
            _authContext = authContext;
            _contextService = contextService;
            _userPermissions = userPermissions;
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
                        Rank = 0
                    }).ToListAsync();

                foreach (var player in players)
                {
                    player.Rank = await _userPermissions.GetGameRankByAccountId(player.RealmId, (RealmType) realm.Id);
                }

                realm.OnlinePlayers = players;
            }

            return Ok(realms);
        }
    }
}