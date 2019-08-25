using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Util;

namespace server.Model
{
    public class RealmModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Online { get; set; }
        public byte AllowedSecurityLevel { get; set; }
        public byte Timezone { get; set; }
        
        // Status Information
        public IEnumerable<PlayerModel> OnlinePlayers { get; set; }
    }
}
