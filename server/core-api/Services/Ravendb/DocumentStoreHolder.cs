using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Raven.Client.Documents;

namespace server.Services.Ravendb
{
    public class DocumentStoreHolder : IDocumentStoreHolder
    {
        public DocumentStoreHolder(IOptions<RavenSettings> ravenSettings, IHostingEnvironment env)
        {
            var settings = ravenSettings.Value;

            var url = env.IsDevelopment() ? settings.DevelopmentUrl : settings.ProductionUrl;

            Store = new DocumentStore
            {
                Urls = new []
                {
                    url
                },
                Database = settings.DefaultDatabase,
                Certificate = env.IsDevelopment() ? null : new X509Certificate2("/home/ubuntu/RavenDB-4.2.3-linux-x64/cluster.server.certificate.titans-league2.pfx")
            }.Initialize();
        }

        public IDocumentStore Store { get; }
    }
}
