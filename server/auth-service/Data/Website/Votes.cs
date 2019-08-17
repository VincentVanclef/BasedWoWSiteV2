using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Data.Website
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
