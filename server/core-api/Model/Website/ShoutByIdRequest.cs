using System.ComponentModel.DataAnnotations;

namespace server.Model.Website
{
    public class ShoutByIdRequest
    {
        [Required]
        public string Id { get; set; }
    }
}
