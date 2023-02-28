using APIServer.Models.Requests;
using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IDataRepository _dataRepository;

        public QuestionsController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public IEnumerable<Question> GetQuestions(string? search)
        {
            IEnumerable<Question> questions;
            if (string.IsNullOrEmpty(search))
            {
                questions = _dataRepository.GetQuestions();
            }
            else
            {
                questions = _dataRepository.GetQuestionsBySearch(search);
            }
            return questions;
        }

        [HttpGet("unanswered")]
        public IEnumerable<Question> GetUnansweredQuestions()
        {
            return _dataRepository.GetUnansweredQuestions();
        }

        [HttpGet("{questionId}")]
        public ActionResult<Question> GetQuestion(int questionId)
        {
            var result = _dataRepository.GetQuestion(questionId);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }

        [HttpPost]
        public ActionResult<Question> PostQuestion(PostQuestionRequestDto questionDto)
        {
            var question = new PostQuestionRequest
            {
                Title = questionDto.Title,
                Content = questionDto.Content,
                UserId = 1,
                UserName = "bob.test@test.com",
                Created = DateTime.UtcNow
            };
            var result = _dataRepository.PostQuestion(question);
            return CreatedAtAction(nameof(GetQuestion), new { questionId = result.QuestionId}, result);
        }

        [HttpPut("{questionId}")]
        public ActionResult<Question> PutQuestion(int questionId, PutQuestionRequest putQuestionRequest)
        {
            var question = _dataRepository.GetQuestion(questionId);

            if(question == null)
            {
                return NotFound();
            }

            putQuestionRequest.Title = string.IsNullOrEmpty(putQuestionRequest.Title) ? question.Title : putQuestionRequest.Title;
            putQuestionRequest.Content = string.IsNullOrEmpty(putQuestionRequest.Content)?question.Content: putQuestionRequest.Content;

            var savedQuestion = _dataRepository.PutQuestion(questionId, putQuestionRequest);
            return savedQuestion;
        }

        [HttpDelete("{questionId}")]
        public ActionResult DeleteQuestion(int questionId)
        {
            var question = GetQuestion(questionId);

            if (question == null)
            {
                return NotFound();
            }

            _dataRepository.DeleteQuestion(questionId);
            return NoContent();
        }

        [HttpPost("{questionId}/answer")]
        public ActionResult<Answer> PostAnswer(int questionId, PostAnswerRequestDto answerDto)
        {
            var questionExists = _dataRepository.QuestionExists(questionId);
            if (!questionExists)
            {
                return NotFound();
            }

            var answer = new PostAnswerRequest
            {
                Content = answerDto.Content,
                UserId = 1,
                UserName = "bob.test@test.com",
                Created = DateTime.UtcNow
            };
            return _dataRepository.PostAnswer(questionId, answer);
        }

    }
}
