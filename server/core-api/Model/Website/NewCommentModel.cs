using System;
using System.ComponentModel.DataAnnotations;

namespace server.Model.Website
{
    [Serializable]
    public class NewCommentModel
    {
        [Required]
        public uint NewsId { get; set; }

        [Required]
        public string Comment { get; set; }
    }
}
