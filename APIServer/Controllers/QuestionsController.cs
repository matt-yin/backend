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
    }
}
