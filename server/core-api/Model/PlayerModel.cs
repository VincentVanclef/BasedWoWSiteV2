using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Util;

namespace server.Model
{
    public class PlayerModel
    {
        public int RealmId { get; set; }
        public string Name { get; set; }
        public byte Race { get; set; }
        public byte Class { get; set; }
        public byte Level { get; set; }
        public short Zone { get; set; }
        public byte Gender { get; set; }
        public byte Rank { get; set; }
        public int AccountId { get; set; }
    }
}
