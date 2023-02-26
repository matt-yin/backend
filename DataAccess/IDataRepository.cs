using DataAccess.Models;

namespace DataAccess
{
    public interface IDataRepository
    {
        IEnumerable<Question> GetQuestions();
        IEnumerable<Question> GetQuestionsBySearch(string search);
        IEnumerable<Question> GetUnansweredQuestions();
        Question GetQuestion(int questionId);
        bool QuestionExists(int questionId);
        Answer GetAnswer(int answerId);
        Question PostQuestion(PostQuestionRequest question);
        Question PutQuestion(int questionId, PutQuestionRequest question);
        void DeleteQuestion(int questionId);
        Answer PostAnswer(int questionId, PostAnswerRequest answer);

    }
}
