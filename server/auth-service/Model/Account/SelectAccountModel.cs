using System;

namespace server.Model.Account
{
    [Serializable]
    public class SelectAccountModel : RealmTypeModel
    {
        public int AccountId { get; set; }
    }
}
