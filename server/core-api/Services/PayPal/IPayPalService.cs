using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayPal.Api;

namespace server.Services.PayPal
{
    public interface IPayPalService
    {
        Task<Payment> CreatePayment(string amount);
        Task<Payment> ExecutePayment(string payerId, string paymentId, string token);
    }
}
