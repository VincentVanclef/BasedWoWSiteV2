using Microsoft.EntityFrameworkCore;

namespace server.Context.Realms.TwinkNation
{
    public class TwinkNationWorldContext : WorldContext
    {
        public TwinkNationWorldContext(DbContextOptions<TwinkNationWorldContext> options)
            : base(options)
        {
        }
    }
}
