using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Data.Website
{
    public class PayPalLog
    {
        public Guid UserId { get; set; }
        public string PaymentId { get; set; }
        public string PayerId { get; set; }
        public string PayerEmail { get; set; }
        public string PayerFirstName { get; set; }
        public string PayerLastName { get; set; }
        public string PayerPostalCode { get; set; }
        public string PayerCity { get; set; }
        public decimal Total { get; set; }
        public string Item { get; set; }
        public int Quantity { get; set; }
        public string Currency { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
    }
}
