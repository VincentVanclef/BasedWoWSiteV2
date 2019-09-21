using Microsoft.EntityFrameworkCore;

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
