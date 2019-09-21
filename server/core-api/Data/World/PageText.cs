using System;
using System.Collections.Generic;

namespace server.Data.World
{
    public partial class PageText
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int NextPageId { get; set; }
        
    }
}
