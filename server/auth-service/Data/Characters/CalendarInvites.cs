using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class CalendarInvites
    {
        public long Id { get; set; }
        public long Event { get; set; }
        public int Invitee { get; set; }
        public int Sender { get; set; }
        public byte Status { get; set; }
        public int Statustime { get; set; }
        public byte Rank { get; set; }
        public string Text { get; set; }
    }
}
