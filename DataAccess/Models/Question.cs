namespace DataAccess.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public DateTime Created { get; set; }
        public IEnumerable<Answer> Answers { get; set; }
    }
}
