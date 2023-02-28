using System.ComponentModel.DataAnnotations;

namespace APIServer.Models.Requests
{
    public class PostQuestionRequestDto
    {
        [StringLength(255)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please include some content for the question.")]
        public string Content { get; set; }
    }
}
