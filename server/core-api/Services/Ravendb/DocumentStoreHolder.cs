using Microsoft.Extensions.Options;
using Raven.Client.Documents;

namespace server.Services.Ravendb
{
    public class DocumentStoreHolder : IDocumentStoreHolder
    {
        public DocumentStoreHolder(IOptions<RavenSettings> ravenSettings)
        {
            var settings = ravenSettings.Value;

            Store = new DocumentStore
            {
                Urls = new []
                {
                    settings.Url
                },
                Database = settings.DefaultDatabase,
                Conventions = { }
            }.Initialize();
        }

        public IDocumentStore Store { get; }
    }
}
