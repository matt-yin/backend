using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class PostQuestionRequest
    {
        [StringLength(255)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please include some content for the question.")]
        public string Content { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public DateTime Created { get; set; }
    }
}
