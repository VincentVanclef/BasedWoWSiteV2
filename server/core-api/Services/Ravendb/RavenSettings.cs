using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Services.Ravendb
{
    public class RavenSettings
    {
        public string Url { get; set; }
        public string DefaultDatabase { get; set; }
    }
}
