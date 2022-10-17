using CollegeMath.Application.DTO;
using CollegeMath.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CollegeMath.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionApplication _questionApplication;
        private string userId = string.Empty;

        public QuestionsController(IQuestionApplication questionApplication, IHttpContextAccessor httpContextAccessor)
        {
            _questionApplication = questionApplication;
            userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
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

        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    return Ok(_questionApplication.GetAll());
        //}

        [HttpPost("getall")]
        public IActionResult GetAllByContentAndLevel(GetAllQuestionDTO getAllQuestionDTO)
        {
            return Ok(_questionApplication.GetAllByContentAndLevel(getAllQuestionDTO, userId));
        }
    }
}
