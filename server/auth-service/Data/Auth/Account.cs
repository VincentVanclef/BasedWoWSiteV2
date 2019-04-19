using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Data.auth
{
    public class Account
    {
        public int Id { get; set; }
        public string PasswordSHA1 { get; set; }
        public string Email { get; set; }
    }
}
