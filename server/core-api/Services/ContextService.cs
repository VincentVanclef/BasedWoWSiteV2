using System;
using server.Context;
using server.Context.Realms.MountOlympus;
using server.Context.Realms.TitansLeague;
using server.Context.Realms.TwinkNation;
using Microsoft.Extensions.DependencyInjection;
using server.Util;

namespace server.Services
{
    public class ContextService
    {
        private readonly IServiceProvider _serviceProvider;

        public ContextService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public CharacterContext GetCharacterContext(RealmType type)
        {
            CharacterContext context = null;

            switch (type)
            {
                case RealmType.TitansLeague:
                {
                    context = _serviceProvider.GetService<TitansLeagueCharacterContext>();
                    break;
                }
                case RealmType.TwinkNation:
                {
                    context = _serviceProvider.GetService<TwinkNationCharacterContext>();
                    break;
                }
                case RealmType.MountOlympus:
                {
                    context = _serviceProvider.GetService<MountOlympusCharacterContext>();
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, $"RealmType {type} is not supported");
            }

            return context;
        }
    }
}
