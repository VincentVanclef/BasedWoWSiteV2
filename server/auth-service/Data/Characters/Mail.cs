using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class Mail
    {
        public int Id { get; set; }
        public byte MessageType { get; set; }
        public byte Stationery { get; set; }
        public short MailTemplateId { get; set; }
        public int Sender { get; set; }
        public int Receiver { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public byte HasItems { get; set; }
        public int ExpireTime { get; set; }
        public int DeliverTime { get; set; }
        public int Money { get; set; }
        public int Cod { get; set; }
        public byte Checked { get; set; }
    }
}
