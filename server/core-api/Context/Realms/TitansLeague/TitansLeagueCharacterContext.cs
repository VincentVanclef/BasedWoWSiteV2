using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using server.Data.Characters;

namespace server.Context.Realms.TitansLeague
{
    public class TitansLeagueCharacterContext : CharacterContext
    {
        public TitansLeagueCharacterContext(DbContextOptions<TitansLeagueCharacterContext> options)
            : base(options)
        {
        }
    }
}
