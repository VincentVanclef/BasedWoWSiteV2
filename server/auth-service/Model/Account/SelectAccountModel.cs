using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Model.Account
{
    [Serializable]
    public class SelectAccountModel : RealmTypeModel
    {
        public int AccountId { get; set; }
    }
}
