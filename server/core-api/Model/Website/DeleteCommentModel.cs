using System.ComponentModel.DataAnnotations;

namespace server.Model.Website
{
    public class DeleteCommentModel
    {
        [Required]
        public int Id { get; set; }
    }
}
