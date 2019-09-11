using System;
using System.ComponentModel.DataAnnotations;

namespace server.Model.Character
{
    [Serializable]
    public class BanCharacterModel : RealmTypeModel
    {
        [Required]
        public int Guid { get; set; }

        [Required]
        public int UnbanDate { get; set; }

        [Required]
        public string Reason { get; set; }
    }
}
