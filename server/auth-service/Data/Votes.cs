using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace server.Data
{
    public class Vote
    {
        [Key, Column(Order = 1)]
        public Guid UserId { get; set; }

        [Key, Column(Order = 2)]
        public byte Site { get; set; }

        [Key, Column(Order = 3)]
        public long UnsetTimer { get; set; }
    }
}
