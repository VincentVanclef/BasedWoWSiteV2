using Microsoft.EntityFrameworkCore;

namespace server.Context.Realms.TitansLeague
{
    public class TitansLeagueWorldContext : WorldContext
    {
        public TitansLeagueWorldContext(DbContextOptions<TitansLeagueWorldContext> options)
            : base(options)
        {
        }
    }
}
