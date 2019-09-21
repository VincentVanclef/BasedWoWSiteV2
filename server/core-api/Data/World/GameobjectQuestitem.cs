using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class GameobjectQuestitem
    {
        public int GameObjectEntry { get; set; }
        public int Idx { get; set; }
        public int ItemId { get; set; }
        public short VerifiedBuild { get; set; }
    }
}
