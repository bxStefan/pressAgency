using System.ComponentModel.DataAnnotations;

namespace pressAgency.Shared.DTO.IDTO
{
    public class PostsIDTO
    {
        [Required(ErrorMessage = "Post title is required field")]
        [StringLength(100, ErrorMessage = "Post title cannot be longer than 100 characters")]
        public required string Title { get; set; }

        [Required(ErrorMessage = "Post content is required field")]
        [StringLength(100, ErrorMessage = "Post content cannot be longer than 1000 characters")]
        public required string Content { get; set; }
    }
}
