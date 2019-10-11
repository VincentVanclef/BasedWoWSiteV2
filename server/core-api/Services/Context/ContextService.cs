using System;
using server.Context;
using server.Context.Realms.TitansLeague;
using server.Context.Realms.TwinkNation;
using Microsoft.Extensions.DependencyInjection;
using server.Util;
using server.Util.Enums;

namespace server.Services.Context
{
    public class ContextService : IContextService
    {
        private readonly IServiceProvider _serviceProvider;

        public ContextService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public CharacterContext GetCharacterContext(RealmType type)
        {
            CharacterContext context;

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
                //case RealmType.MountOlympus:
                //{
                //    context = _serviceProvider.GetService<MountOlympusCharacterContext>();
                //    break;
                //}
                //case RealmType.Helios:
                //{
                //    context = _serviceProvider.GetService<HeliosCharacterContext>();
                //    break;
                //}
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, $"RealmType {type} is not supported");
            }

            return context;
        }

        public WorldContext GetWorldContext(RealmType type)
        {
            WorldContext context;

            switch (type)
            {
                case RealmType.TitansLeague:
                {
                    context = _serviceProvider.GetService<TitansLeagueWorldContext>();
                    break;
                }
                case RealmType.TwinkNation:
                {
                    context = _serviceProvider.GetService<TwinkNationWorldContext>();
                    break;
                }
                //case RealmType.MountOlympus:
                //{
                //    context = _serviceProvider.GetService<MountOlympusWorldContext>();
                //    break;
                //}
                //case RealmType.Helios:
                //{
                //    context = _serviceProvider.GetService<HeliosWorldContext>();
                //    break;
                //}
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, $"RealmType {type} is not supported");
            }

            return context;
        }
    }
}
