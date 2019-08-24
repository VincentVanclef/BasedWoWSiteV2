using System;
using System.ComponentModel.DataAnnotations;
using server.Util;

namespace server.Model
{
    [Serializable]
    public class RealmTypeModel
    {
        [Required]
        public RealmType RealmType { get; set; }
    }
}
