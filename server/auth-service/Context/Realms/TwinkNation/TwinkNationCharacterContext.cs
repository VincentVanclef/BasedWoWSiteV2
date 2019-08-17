using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using server.Data.Characters;

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
