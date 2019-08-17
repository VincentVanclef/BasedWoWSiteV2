using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class Auctionhouse
    {
        public int Id { get; set; }
        public byte Houseid { get; set; }
        public int Itemguid { get; set; }
        public int Itemowner { get; set; }
        public int Buyoutprice { get; set; }
        public int Time { get; set; }
        public int Buyguid { get; set; }
        public int Lastbid { get; set; }
        public int Startbid { get; set; }
        public int Deposit { get; set; }
    }
}
