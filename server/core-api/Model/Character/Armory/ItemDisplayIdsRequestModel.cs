using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace server.Model.Character.Armory
{
    public class ItemDisplayIdsRequestModel
    {
        [Required]
        public List<int> DisplayIds { get; set; }
    }
}
