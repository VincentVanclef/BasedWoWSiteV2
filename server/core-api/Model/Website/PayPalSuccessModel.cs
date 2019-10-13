using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Data.Website
{
    public class PayPalSuccessModel
    {
        public Guid UserId { get; set; }
        public int AccountId { get; set; }
        public string PayerId { get; set; }
        public string PaymentId { get; set; }
        public string Token { get; set; }
    }
}
