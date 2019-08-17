using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace server.Data.Realms
{
    [Serializable]
    public class Realm
    {
        public RealmInformation.RealmType RealmType { get; set; } 
        public string Name { get; set; }
        public string CharacterConnection { get; set; }
    }

    public static class RealmInformation
    {
        public enum RealmType
        {
            TitansLeague = 1,
            TwinkNation = 2,
            MountOlympus = 3
        }
    }
}
