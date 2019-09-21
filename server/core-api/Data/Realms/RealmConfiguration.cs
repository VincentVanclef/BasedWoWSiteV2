using System;
using server.Util;

namespace server.Data.Realms
{
    [Serializable]
    public class Realm
    {
        public RealmType RealmType { get; set; } 
        public string Name { get; set; }
        public string CharacterConnection { get; set; }
        public string WorldConnection { get; set; }
    }
}
