using CollegeMath.Application.DTO;
using CollegeMath.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CollegeMath.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionApplication _questionApplication;

        public QuestionsController(IQuestionApplication questionApplication)
        {
            _questionApplication = questionApplication;
        }

        [HttpPost]
        public IActionResult Insert(QuestionDTO questionDTO)
        {
            _questionApplication.Insert(questionDTO);
            return Ok(new { Sucesso = true });
        }
        [HttpPut]
        public IActionResult Update(QuestionDTO questionDTO)
        {
            _questionApplication.Update(questionDTO);
            return Ok(new { Sucesso = true });
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return NotFound();

            _questionApplication.Delete(id);
            return Ok(new { Sucesso = true });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_questionApplication.GetAll());
        }
    }
}
