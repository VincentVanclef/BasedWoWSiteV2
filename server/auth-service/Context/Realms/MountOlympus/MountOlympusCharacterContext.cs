using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using server.Data.Characters;
using server.Data.Realms;

namespace server.Context.Realms.MountOlympus
{
    public class MountOlympusCharacterContext : CharacterContext
    {
        public MountOlympusCharacterContext(DbContextOptions<MountOlympusCharacterContext> options)
            : base(options)
        {
        }
    }
}
