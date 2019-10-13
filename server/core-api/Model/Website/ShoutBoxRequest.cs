using System;

namespace server.Model.Website
{
    [Serializable]
    public class ShoutBoxRequest
    {
        public int Count { get; set; } = 5;
    }
}
