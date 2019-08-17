using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class MailItems
    {
        public int MailId { get; set; }
        public int ItemGuid { get; set; }
        public int Receiver { get; set; }
    }
}
