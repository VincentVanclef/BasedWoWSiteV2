using System.ComponentModel.DataAnnotations;

namespace server.Model.Website
{
    public class DeleteNewsModel
    {
        [Required]
        public int Id { get; set; }
    }
}
