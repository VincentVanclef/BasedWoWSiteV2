using Microsoft.EntityFrameworkCore;

namespace server.Context.Realms.Helios
{
    public class HeliosWorldContext : WorldContext
    {
        public HeliosWorldContext(DbContextOptions<HeliosWorldContext> options)
            : base(options)
        {
        }
    }
}
