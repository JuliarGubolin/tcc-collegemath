using CollegeMath.Application.DTO;
using CollegeMath.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CollegeMath.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlternativesController : ControllerBase
    {
        private readonly IAlternativeApplication _alternativeApplication;

        public AlternativesController(IAlternativeApplication alternativeApplication)
        {
            _alternativeApplication = alternativeApplication;
        }

        [HttpPost]
        public IActionResult Insert(AlternativeDTO alternativeDTO)
        {
            _alternativeApplication.Insert(alternativeDTO);
            return Ok(new { Sucesso = true });
        }
        [HttpPut]
        public IActionResult Update(AlternativeDTO alternativeDTO)
        {
            _alternativeApplication.Update(alternativeDTO);
            return Ok(new { Sucesso = true });
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return NotFound();

            _alternativeApplication.Delete(id);
            return Ok(new { Sucesso = true });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_alternativeApplication.GetAll());
        }
    }
}
