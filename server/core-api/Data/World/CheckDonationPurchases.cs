using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class CheckDonationPurchases
    {
        public int Id { get; set; }
        public string CharName { get; set; }
        public int AccId { get; set; }
        public string ItemName { get; set; }
        public int ItemId { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}
