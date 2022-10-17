using CollegeMath.Application.DTO;
using CollegeMath.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollegeMath.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageSolutionController : ControllerBase
    {
        private readonly IImageSolutionApplication _imageSolutionApplication;
        public ImageSolutionController(IImageSolutionApplication imageSolutionApplication)
        {
            _imageSolutionApplication = imageSolutionApplication;
        }

        [HttpPost]
        public IActionResult Insert(ImageSolutionDTO imageSolutionDTO) 
        {
            _imageSolutionApplication.Insert(imageSolutionDTO);
            return Ok();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_imageSolutionApplication.GetAll());
        }
    }
}
