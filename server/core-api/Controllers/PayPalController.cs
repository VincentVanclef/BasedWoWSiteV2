using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.ApiExtensions;
using server.Services.PayPal;
using PayPal.Api;
using server.Context;
using server.Data.Website;
using server.Util;

namespace server.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class PayPalController : ControllerBase
    {
        private readonly PayPalService _payPalService;
        private readonly AuthContext _authContext;
        private readonly WebsiteContext _websiteContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public PayPalController(PayPalService payPalService, AuthContext authContext, WebsiteContext websiteContext, UserManager<ApplicationUser> userManager)
        {
            _payPalService = payPalService;
            _authContext = authContext;
            _websiteContext = websiteContext;
            _userManager = userManager;
        }

        [Authorize]
        [HttpGet("GetAllDonations")]
        public async Task<IActionResult> GetAllDonations()
        {
            var user = await TokenHelper.GetUser(User, _userManager);
            if (user == null)
                return RequestHandler.Unauthorized();

            var logs = await _websiteContext.PayPalLogs.Where(x => x.UserId == user.Id).ToListAsync();
            return Ok(logs);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("GetAllDonations/{id}")]
        public async Task<IActionResult> GetAllDonations(Guid id)
        {
            var logs = await _websiteContext.PayPalLogs.Where(x => x.UserId == id).ToListAsync();
            return Ok(logs);
        }

        [Authorize]
        [HttpPost("Donate")]
        public async Task<IActionResult> CreatePayment([FromBody] PayPalDonateModel model)
        {
            var result = await _payPalService.CreatePayment(model.Amount.ToString());

            foreach (var link in result.links)
            {
                if (link.rel.Equals("approval_url"))
                {
                    return Ok(link.href);
                }
            }

            return RequestHandler.BadRequest("Unable to process payment");
        }

        [Authorize]
        [HttpPost("ExecutePayment")]
        public async Task<IActionResult> ExecutePayment([FromBody] PayPalSuccessModel model)
        {
            var accountData = await _authContext.AccountData.FirstOrDefaultAsync(x => x.Id == model.AccountId);

            var payPalLog = await RetrievePaymentDetails(model);
            if (payPalLog != null)
            {
                return Ok(new { dp = accountData.Dp, payPalLog });
            }

            Payment payment;

            try
            {
                payment = await _payPalService.ExecutePayment(model.PayerId, model.PaymentId, model.Token);
            }
            catch (Exception e)
            {
                return RequestHandler.BadRequest(e.Message);
            }

            foreach (var resultTransaction in payment.transactions)
            {
                foreach (var item in resultTransaction.item_list.items)
                {
                    int.TryParse(item.quantity, out var amount);
                    accountData.Dp += amount;
                }
            }

            await _authContext.SaveChangesAsync();

            payPalLog = await SavePaymentDetails(payment, model);

            return Ok(new { dp = accountData.Dp, payPalLog });
        }

        private async Task<PayPalLog> RetrievePaymentDetails(PayPalSuccessModel model)
        {
            return await _websiteContext.PayPalLogs.FirstOrDefaultAsync(x =>
                x.UserId == model.UserId && x.PayerId == model.PayerId && x.PaymentId == model.PaymentId);
        }

        private async Task<PayPalLog> SavePaymentDetails(Payment payment, PayPalSuccessModel model)
        {
            var total = decimal.Parse(payment.transactions[0].amount.total, CultureInfo.InvariantCulture);
            var price = decimal.Parse(payment.transactions[0].item_list.items[0].price, CultureInfo.InvariantCulture);
            int.TryParse(payment.transactions[0].item_list.items[0].quantity, out var quantity);

            var payerInfo = payment.payer.payer_info;
            var shippingInfo = payerInfo.shipping_address;

            var payPalLog = new PayPalLog()
            {
                UserId = model.UserId,
                PayerId = model.PayerId,
                PaymentId = model.PaymentId,
                Total = total,
                Currency = "USD",
                Date = DateTime.Now,
                PayerFirstName = payerInfo.first_name,
                PayerLastName = payerInfo.last_name,
                PayerEmail = payerInfo.email,
                Item = "Donation Point",
                Price = price,
                Quantity = quantity,
                PayerPostalCode = shippingInfo.postal_code,
                PayerCity = shippingInfo.city
            };

            await _websiteContext.PayPalLogs.AddAsync(payPalLog);
            await _websiteContext.SaveChangesAsync();

            return payPalLog;
        }
    }
}