using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing.Constraints;

namespace server.Model.Website
{
    [Serializable]
    public class NewCommentModel : AuthorModel
    {
        public int NewsId { get; set; }
        public string Comment { get; set; }
    }
}
