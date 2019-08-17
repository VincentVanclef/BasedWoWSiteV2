using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Model.Character
{
    public class SelectCharacterByGuidModel : RealmTypeModel
    {
        public int Guid { get; set; }
    }
}
