using CollegeMath.Application.DTO;
using CollegeMath.Infra.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollegeMath.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
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

        [HttpGet("UserHistory", Name = "UserHistory")]
        public IActionResult GetUserHistory()
        {
            return Ok();
        }
    }
}
