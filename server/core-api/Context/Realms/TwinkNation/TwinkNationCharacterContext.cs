using Microsoft.EntityFrameworkCore;

namespace server.Context.Realms.TwinkNation
{
    public class TwinkNationCharacterContext : CharacterContext
    {
        public TwinkNationCharacterContext(DbContextOptions<TwinkNationCharacterContext> options)
            : base(options)
        {
        }
    }
}
