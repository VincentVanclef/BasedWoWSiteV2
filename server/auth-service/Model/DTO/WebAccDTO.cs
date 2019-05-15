using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Model
{
    public class WebAccDTO
    {
        public string Id { get; set; }
        public int AccountId { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int VP { get; set; }
        public int DP { get; set; }
        public DateTime JoinDate { get; set; }
        public string Location { get; set; }

        public int Rank { get; set; }
    }
}
