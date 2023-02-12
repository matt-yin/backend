using Dapper;
using Microsoft.Data.SqlClient;
using DataAccess.Models;
using Microsoft.Extensions.Configuration;

namespace DataAccess
{
    public class DataRepository : IDataRepository
    {
        private readonly string _connectionString;

        public DataRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void DeleteQuestion(int questionId)
        {
            throw new NotImplementedException();
        }

        public Answer GetAnswer(int answerId)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection.QueryFirstOrDefault<Answer>(@"EXEC dbo.Answer_GetById @AnswerId = @AnswerId", new { AnswerId = answerId });
        }

        public Question GetQuestion(int questionId)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var question = connection.QueryFirstOrDefault<Question>(@"EXEC dbo.Question_GetById @QuestionId = @QuestionId", new {QuestionId = questionId });
            if (question!=null)
            {
                question.Answers = connection.Query<Answer>(@"EXEC dbo.Answer_GetByQuestionId @QuestionId = @QuestionId", new { question.QuestionId });
            }
            return question;
        }

        public IEnumerable<Question> GetQuestions()
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection.Query<Question>(@"EXEC dbo.Question_Get");
        }

        public IEnumerable<Question> GetQuestionsBySearch(string search)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection.Query<Question>(@"EXEC dbo.Question_Search @Search = @Search", new { Search = search });
        }

        public IEnumerable<Question> GetUnansweredQuestions()
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection.Query<Question>(@"EXEC Question_Unanswered");
        }

        public Answer PostAnswer(Answer answer)
        {
            throw new NotImplementedException();
        }

        public Question PostQuestion(PostQuestionRequest question)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            int questionId = connection.QueryFirst<int>(@"EXEC Question_Post @Title = @Title, @Content = @Content, @UserId = @UserId, @UserName = @UserName, @Created = @Created", question);
            return GetQuestion(questionId);
        }

        public Question PutQuestion(int questionId, Question question)
        {
            throw new NotImplementedException();
        }

        public bool QuestionExists(int questionId)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection.QueryFirst<bool>(@"EXEC Question_Exists @QuestionId = @QuestionId", new { QuestionId = questionId });
        }
    }
}
