using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Security
{
    public class IpSecuritySettings
    {
        public string BlockedIps { get; set; }
        public List<string> BlockedIPsList => !string.IsNullOrEmpty(BlockedIps) ? BlockedIps.Split(',').ToList() : new List<string>();
    }
}
