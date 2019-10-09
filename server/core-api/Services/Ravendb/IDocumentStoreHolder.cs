using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Raven.Client.Documents;

namespace server.Services.Ravendb
{
    public interface IDocumentStoreHolder
    {
        IDocumentStore Store { get; }
    }
}
