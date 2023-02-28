namespace DataAccess.Models
{
    public class PostAnswerRequest
    {
        public string Content { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public DateTime Created { get; set; }
    }
}
