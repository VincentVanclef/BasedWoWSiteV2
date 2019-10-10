using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Raven.Client.Documents;
using Microsoft.Extensions.Configuration;

namespace server.Services.Ravendb
{
    public class DocumentStoreHolder : IDocumentStoreHolder
    {
        private readonly IHostingEnvironment _env;

        public DocumentStoreHolder(IOptions<RavenSettings> ravenSettings, IHostingEnvironment env)
        {
            _env = env;

            var settings = ravenSettings.Value;

            var url = env.IsDevelopment() ? settings.DevelopmentUrl : settings.ProductionUrl;

            Store = new DocumentStore
            {
                Urls = new []
                {
                    url
                },
                Database = settings.DefaultDatabase,
                Conventions = { },
                Certificate = env.IsDevelopment() ? null : new X509Certificate2("/home/ubuntu/RavenDB-4.2.3-linux-x64/cluster.server.certificate.titans-league2.pfx")
            }.Initialize();
        }

        public IDocumentStore Store { get; }
    }
}
