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

        public RealmController(AuthContext authContext, ContextService contextService)
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
                   Port = x.Port,
                   AllowedSecurityLevel = x.AllowedSecurityLevel,
                   Timezone = x.Timezone
                }).ToListAsync();

            foreach (var realm in realms)
            {
                var context = _contextService.GetCharacterContext((RealmType)realm.Id);
                var result = await context
                    .Characters
                    .Where(x => x.IsOnline())
                    .Select(x => new PlayerModel
                    {
                        Name = x.Name,
                        Race = x.Race,
                        Class = x.Class,
                        Level = x.Level,
                        Zone = x.Zone,
                        Gender = x.Gender
                    }).ToListAsync();

                realm.OnlinePlayers = result;
            }

            return Ok(realms);
        }
    }
}