using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using PayPal.Api;
using server.ApiExtensions;

namespace server.Services.PayPal
{
    public class PayPalService
    {
        private readonly IConfiguration _configuration;
        private readonly string _mode;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _returnUrl;
        private readonly string _cancelUrl;

        public PayPalService(IConfiguration configuration, IHostingEnvironment env)
        {
            _configuration = configuration;
            _clientId = env.IsDevelopment() ? configuration.GetSection("PayPal")["ClientIdDev"] : configuration.GetSection("PayPal")["ClientIdProd"];
            _clientSecret = env.IsDevelopment() ? configuration.GetSection("PayPal")["ClientSecretDev"] : configuration.GetSection("PayPal")["ClientSecretProd"];
            _mode = env.IsDevelopment() ? configuration.GetSection("PayPal")["ModeDev"] : configuration.GetSection("PayPal")["ModeProd"];
            _returnUrl = env.IsDevelopment() ? configuration.GetSection("PayPal")["ReturnUrlDev"] : configuration.GetSection("PayPal")["ReturnUrlProd"];
            _cancelUrl = env.IsDevelopment() ? configuration.GetSection("PayPal")["CancelUrlDev"] : configuration.GetSection("PayPal")["CancelUrlProd"];
        }

        public Dictionary<string, string> GetConfig()
        {
            var configurationMap = new Dictionary<string, string>
            {
                {"clientId", _clientId}, {"clientSecret", _clientSecret}, {"mode", _mode}
            };

            return configurationMap;
        }

        private APIContext ApiContext(string accessToken)
        {
            return new APIContext(accessToken) { Config = GetConfig() };
        }

        private string CreateAuthToken()
        {
            return new OAuthTokenCredential(GetConfig()).GetAccessToken();
        }

        public async Task<Payment> CreatePayment(string amount)
        {
            Payment createdPayment;

            try
            {
                var payment = new Payment
                {
                    intent = "sale",
                    payer = new Payer { payment_method = "paypal" },
                    transactions = new List<Transaction>
                    {
                        new Transaction
                        {
                            amount = new Amount
                            {
                                currency = "USD",
                                total = amount
                            },
                            item_list = new ItemList()
                            {
                                items = new List<Item>()
                                {
                                    new Item()
                                    {
                                        name = "Donation Point",
                                        price = "1", 
                                        quantity = amount,
                                        currency = "USD",
                                        sku = "sku"
                                    }
                                }
                            },
                            description = "Donation Points"
                        }
                    },
                    redirect_urls = new RedirectUrls
                    {
                        cancel_url = _cancelUrl,
                        return_url = _returnUrl
                    }
                };

                createdPayment = await Task.Run(() => payment.Create(ApiContext(CreateAuthToken())));
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }

            return createdPayment;
        }

        public async Task<Payment> ExecutePayment(string payerId, string paymentId, string token)
        {
            var apiContext = new APIContext(CreateAuthToken())
            {
                Config = GetConfig()
            };

            var paymentExecution = new PaymentExecution() { payer_id = payerId };
            var payment = new Payment()
            {
                id = paymentId,
                token = token
            };

            var executedPayment = await Task.Run(() => payment.Execute(apiContext, paymentExecution));
            return executedPayment;
        }
    }
}
