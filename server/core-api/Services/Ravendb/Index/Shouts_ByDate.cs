using System.Linq;
using Raven.Client.Documents.Indexes;
using server.Data.Website;

namespace server.Services.Ravendb.Index
{
    public class Shouts_ByDate : AbstractIndexCreationTask<Shout>
    {
        public Shouts_ByDate()
        {
            Map = shouts => from shout in shouts
                            select new 
                            {
                                Date = shout.Date
                            };
        }
    }
}
