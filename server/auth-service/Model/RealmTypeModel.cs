using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Data.Realms;

namespace server.Model
{
    [Serializable]
    public abstract class RealmTypeModel
    {
        public RealmInformation.RealmType RealmType { get; set; }
    }
}
