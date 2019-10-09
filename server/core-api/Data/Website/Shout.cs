using System;

namespace server.Data.Website
{
    public class Shout
    {
        public string Id { get; set; }
        public Guid User { get; set; }
        public DateTime Date { get; set; }

    }
}