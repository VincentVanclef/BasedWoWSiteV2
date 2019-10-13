using System.ComponentModel.DataAnnotations;

namespace server.Data.Website
{
    public class ShoutByIdRequest
    {
        [Required]
        public string Id { get; set; }
    }
}
