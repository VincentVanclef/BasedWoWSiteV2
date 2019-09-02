using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayPal.Api;
using Renci.SshNet;
using server.ApiExtensions;
using server.Services.PayPal;

namespace server.Controllers
{
    /*[Route("/[controller]")]
    [ApiController]
    public class PayPalController : ControllerBase
    {
        private readonly PayPalService _payPalService;
        private Payment _payment;

        public PayPalController(PayPalService payPalService)
        {
            _payPalService = payPalService;
        }

        [Authorize]
        [HttpPost("Donate")]
        public IActionResult Donate()
        {
            var apiContext = _payPalService.GetApiContext();
            try
            {
                string payerId = Request.Query["PayerID"];
                if (string.IsNullOrEmpty(payerId))
                {
                    var createdPayment = CreatePayment(apiContext, _payPalService.ReturnUrl);
                    //get links returned from paypal in response to Create function call  
                    using (var links = createdPayment.links.GetEnumerator())
                    {
                        string paypalRedirectUrl = null;
                        while (links.MoveNext())
                        {
                            Links lnk = links.Current;
                            if (lnk.rel.ToLower().Trim().Equals("approval_url"))
                            {
                                //saving the payapalredirect URL to which user will be redirected for payment  
                                paypalRedirectUrl = lnk.href;
                            }
                        }
                        return Ok(paypalRedirectUrl);
                    }
                }
                else
                {

                }
            }
            catch (Exception e)
            {
                return RequestHandler.BadRequest(e.Message);
            }

            return Ok();
        }

        private Payment CreatePayment(APIContext apiContext, string redirectUrl)
        {
            //create itemlist and add item objects to it  
            var itemList = new ItemList()
            {
                items = new List<Item>()
            };
            //Adding Item Details like name, currency, price etc  
            itemList.items.Add(new Item()
            {
                name = "Donation Point",
                currency = "USD",
                price = "1",
                quantity = "1",
                sku = "item"
            });
            var payer = new Payer()
            {
                payment_method = "paypal"
            };
            // Configure Redirect Urls here with RedirectUrls object  
            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl + "&Cancel=true",
                return_url = redirectUrl
            };
            // Adding Tax, shipping and Subtotal details  
            var details = new Details()
            {
                tax = "1",
                shipping = "1",
                subtotal = "1"
            };
            //Final amount with details  
            var amount = new Amount()
            {
                currency = "USD",
                total = "1", // Total must be equal to sum of tax, shipping and subtotal.  
                details = details
            };
            var transactionList = new List<Transaction>();
            // Adding description about the transaction  
            transactionList.Add(new Transaction()
            {
                description = "Transaction description",
                invoice_number = Convert.ToString((new Random()).Next(100000)), //Generate an Invoice No  
                amount = amount,
                item_list = itemList
            });
            _payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };
            // Create a payment using a APIContext  
            return _payment.Create(apiContext);
        }

        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerId
            };

            this._payment = new Payment()
            {
                id = paymentId
            };

            return this._payment.Execute(apiContext, paymentExecution);
        }
    }*/
}