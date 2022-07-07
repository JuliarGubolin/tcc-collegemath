using CollegeMath.Application.DTO;
using CollegeMath.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollegeMath.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContentsController : ControllerBase
    {
        private readonly IContentApplication _contentApplication;

        public ContentsController(IContentApplication contentApplication)
        {
            _contentApplication = contentApplication;
        }

        [HttpPost]
        public IActionResult Insert(ContentDTO contentDTO)
        {
            _contentApplication.Insert(contentDTO);
            return Ok(new { Sucesso = true });
        }
        [HttpPut]
        public IActionResult Update(ContentDTO contentDTO)
        {
            _contentApplication.Update(contentDTO);
            return Ok(new { Sucesso = true });
        }
        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_contentApplication.GetAll());
        }

        //[HttpGet(Name = "Details")]
        //public IActionResult GetById(int id)
        //{
        //    return Ok();
        //}

    }
}
