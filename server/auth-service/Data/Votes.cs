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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Guid UserId { get; set; }

        public byte Site { get; set; }

        public long UnsetTimer { get; set; }
    }
}
