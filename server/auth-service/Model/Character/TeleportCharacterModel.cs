using System;

namespace server.Model.Character
{
    [Serializable]
    public class TeleportCharacterModel : RealmTypeModel
    {
        public int Guid { get; set; }
        public int Location { get; set; }
    }
}
