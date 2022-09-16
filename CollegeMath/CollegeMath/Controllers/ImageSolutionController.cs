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
        private readonly IImageSolutionApplication _imageSolutionApplciation;
        public ImageSolutionController(IImageSolutionApplication imageSolutionApplication)
        {
            _imageSolutionApplciation = imageSolutionApplication;
        }

        [HttpPost]
        public IActionResult Insert(ImageSolutionDTO imageSolutionDTO) 
        {
            _imageSolutionApplciation.Insert(imageSolutionDTO);
            return Ok();
        }
    }
}
