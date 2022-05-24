using CollegeMath.Application.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollegeMath.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        public IActionResult Insert(UsuarioDTO usuarioDTO)
        {
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(UsuarioDTO usuarioDTO)
        {
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            return Ok();
        }
        [HttpGet]
        public IActionResult GetAll(UsuarioDTO usuarioDTO)
        {
            return Ok();
        }
        [HttpGet("Details", Name ="Details")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }
    }
}
