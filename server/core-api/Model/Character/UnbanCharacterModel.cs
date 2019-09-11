using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.Model.Character
{
    [Serializable]
    public class UnBanCharacterModel : RealmTypeModel
    {
        [Required]
        public int Guid { get; set; }
    }
}
