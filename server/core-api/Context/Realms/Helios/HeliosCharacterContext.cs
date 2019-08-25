using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using server.Data.Characters;

namespace server.Context.Realms.Helios
{ 
    public class HeliosCharacterContext : CharacterContext
    {
        public HeliosCharacterContext(DbContextOptions<HeliosCharacterContext> options)
            : base(options)
        {
        }
    }
}
