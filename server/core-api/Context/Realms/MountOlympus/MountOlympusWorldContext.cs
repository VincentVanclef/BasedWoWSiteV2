using Microsoft.EntityFrameworkCore;

namespace server.Context.Realms.MountOlympus
{
    public class MountOlympusWorldContext : WorldContext
    {
        public MountOlympusWorldContext(DbContextOptions<MountOlympusWorldContext> options)
            : base(options)
        {
        }
    }
}
