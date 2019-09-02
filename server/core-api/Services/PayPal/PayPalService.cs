using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace server.Services.PayPal
{
    public class PayPalService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public readonly string ClientId;
        public readonly string ClientSecret;
        public readonly string ReturnUrl;

        public PayPalService(IConfiguration configuration, IHostingEnvironment env)
        {
            _httpClient = new HttpClient();
            _configuration = configuration;
            ClientId = configuration.GetSection("PayPal")["ClientId"];
            ClientSecret = configuration.GetSection("PayPal")["ClientSecret"];
            ReturnUrl = env.IsDevelopment() ? configuration.GetSection("PayPal")["ReturnUrlDev"] : configuration.GetSection("PayPal")["ReturnUrlProd"];
        }
    }
}
