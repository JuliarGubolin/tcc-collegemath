using CollegeMath.Application.DTO;
using CollegeMath.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollegeMath.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolutionsController : ControllerBase
    {
        private readonly ISolutionApplication _solutionApplication;
        public SolutionsController(ISolutionApplication solutionApplication)
        {
            _solutionApplication = solutionApplication;
        }
        
        //[HttpGet("get-solution-by-questionid")]
        //public IActionResult GetSolutionByQuestionId(int questionId)
        //{
        //    return Ok(_solutionApplication.GetSolutionByQuestionId(questionId));
        //}

        [HttpPost]
        public IActionResult Insert(SolutionDTO solutionDTO) 
        {
            _solutionApplication.Insert(solutionDTO);
            return Ok();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_solutionApplication.GetAll());
        }
        [HttpPut]
        public IActionResult Update(SolutionDTO solutionDTO)
        {
            _solutionApplication.Update(solutionDTO);
            return Ok(new { Sucesso = true });
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return NotFound();

            _solutionApplication.Delete(id);
            return Ok(new { Sucesso = true });
        }
    }
}
