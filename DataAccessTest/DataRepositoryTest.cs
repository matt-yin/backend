using DataAccess;
using DataAccess.Models;
using Microsoft.Extensions.Configuration;

namespace DataAccessTest
{
    [TestClass]
    public class DataRepositoryTest
    {
        private static readonly DataRepository _dataRepository;

        static DataRepositoryTest()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("TestConfig.json").Build();
            _dataRepository = new DataRepository(configuration);
        }

        [TestMethod]
        public void GetQuestions_Succeeds()
        {
            var result = _dataRepository.GetQuestions().ToList();

            Assert.IsTrue(result.Count >= 1);
        }

        [TestMethod]
        public void GetQuestion_Succeeds()
        {
            var result = _dataRepository.GetQuestion(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.QuestionId);
            Assert.IsTrue(result.Answers.ToList().Count > 1);
        }

        [TestMethod]
        public void GetQuestionsBySearch_Succeeds()
        {
            string search = "type";

            var result = _dataRepository.GetQuestionsBySearch(search).ToList();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count >= 1);
            Assert.IsTrue(result[0].Title.Contains(search, StringComparison.OrdinalIgnoreCase) || result[0].Content.Contains(search, StringComparison.OrdinalIgnoreCase));
        }

        [TestMethod]
        public void GetUnansweredQuestions_Succeeds()
        {
            var result = _dataRepository.GetUnansweredQuestions().ToList();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count >= 1);
            Assert.IsNull(result[0].Answers);
        }

        [TestMethod]
        public void PostQuestion_Succeeds()
        {
            DateTime utcNow = DateTime.UtcNow;
            var newQuestion = new PostQuestionRequest
            {
                Title = "Integration Test - Title",
                Content = "Integration Test - Content",
                UserId = 1,
                UserName = "Integration Test - UserName",
                Created = utcNow
            };

            var result = _dataRepository.PostQuestion(newQuestion);

            Assert.IsNotNull(result);
            Assert.AreEqual("Integration Test - Title", result.Title);
            Assert.AreEqual("Integration Test - Content", result.Content);
            Assert.AreEqual(1, result.UserId);
            Assert.AreEqual("Integration Test - UserName", result.UserName);
            Assert.IsTrue(result.Created.Subtract(utcNow).TotalMilliseconds < 1);
        }

        [TestMethod]
        public void QuestionExists_Exists()
        {
            var result = _dataRepository.QuestionExists(1);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void QuestionExists_NotExists()
        {
            var result = _dataRepository.QuestionExists(9999);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetAnswer_Succeeds()
        {
            var result = _dataRepository.GetAnswer(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.AnswerId);
        }
    }
}