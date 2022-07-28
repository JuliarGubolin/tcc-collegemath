using CollegeMath.Application.DTO;
using CollegeMath.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CollegeMath.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ImageQuestionController : ControllerBase
    {
        private readonly IImageQuestionApplication _imagequestionApplication;

        public ImageQuestionController(IImageQuestionApplication imagequestionApplication)
        {
            _imagequestionApplication = imagequestionApplication;
        }

        [HttpPost]
        public IActionResult Insert(ImageQuestionDTO imageQuestionDTO)
        {
            _imagequestionApplication.Insert(imageQuestionDTO);
            return Ok(new { Sucesso = true });
        }
        [HttpPut]
        public IActionResult Update(ImageQuestionDTO imageQuestionDTO)
        {
            _imagequestionApplication.Update(imageQuestionDTO);
            return Ok(new { Sucesso = true });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_imagequestionApplication.GetAll());
        }
    }
}
