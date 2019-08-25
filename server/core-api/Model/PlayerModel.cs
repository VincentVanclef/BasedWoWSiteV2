using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Model
{
    public class PlayerModel
    {
        public string Name { get; set; }
        public byte Race { get; set; }
        public byte Class { get; set; }
        public byte Level { get; set; }
        public short Zone { get; set; }
        public byte Gender { get; set; }
    }
}
