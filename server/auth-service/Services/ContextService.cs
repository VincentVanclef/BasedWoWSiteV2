using System;
using server.Context;
using server.Context.Realms.MountOlympus;
using server.Context.Realms.TitansLeague;
using server.Context.Realms.TwinkNation;
using server.Data.Realms;
using Microsoft.Extensions.DependencyInjection;

namespace server.Services
{
    public class ContextService
    {
        private readonly IServiceProvider _serviceProvider;

        public ContextService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public CharacterContext GetCharacterContext(RealmInformation.RealmType type)
        {
            CharacterContext context = null;

            switch (type)
            {
                case RealmInformation.RealmType.TitansLeague:
                {
                    context = _serviceProvider.GetService<TitansLeagueCharacterContext>();
                    break;
                }
                case RealmInformation.RealmType.TwinkNation:
                {
                    context = _serviceProvider.GetService<TwinkNationCharacterContext>();
                    break;
                }
                case RealmInformation.RealmType.MountOlympus:
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
