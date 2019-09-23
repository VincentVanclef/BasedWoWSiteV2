using System;

namespace server.Model.Character
{
    [Serializable]
    public class SelectCharacterByNameModel : RealmTypeModel
    {
        public string Name { get; set; }
    }
}
