using System;
using System.ComponentModel.DataAnnotations;
using server.Util;
using server.Util.Enums;

namespace server.Model
{
    [Serializable]
    public class RealmTypeModel
    {
        [Required]
        public RealmType RealmType { get; set; }
    }
}
