using CollegeMath.Application.DTO;
using CollegeMath.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CollegeMath.Controllers
{
    public class LevelController : Controller
    {
        private readonly ILevelApplication _levelApplication;

        public LevelController(ILevelApplication levelApplication)
        {
            _levelApplication = levelApplication;
        }

        [HttpPost]
        public IActionResult Insert(LevelDTO levelDTO)
        {
            _levelApplication.Insert(levelDTO);
            return Ok(new { Sucesso = true });
        }
        [HttpPut]
        public IActionResult Update(LevelDTO levelDTO)
        {
            _levelApplication.Update(levelDTO);
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
            return Ok(_levelApplication.GetAll());
        }
    }
}
