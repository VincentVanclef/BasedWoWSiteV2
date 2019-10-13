using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace server.Model.Website
{
    [Serializable]
    public class ShoutBoxRequest
    {
        public int Count { get; set; } = 5;
    }
}
