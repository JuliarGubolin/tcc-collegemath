using CollegeMath.Application.DTO;
using CollegeMath.Application.Interfaces;
using CollegeMath.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CollegeMath.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserQuestionHistoryController : ControllerBase
    {
        private readonly IUserQuestionHistoryApplication _userQuestionHistoryApplication;
        private readonly UserManager<ApplicationUser> _userManager;
        private string userId = string.Empty;
        public UserQuestionHistoryController(IUserQuestionHistoryApplication userQuestionHistoryApplication, UserManager<ApplicationUser> userManager,
            IHttpContextAccessor httpContextAccessor)
        {
            _userQuestionHistoryApplication = userQuestionHistoryApplication;
            _userManager = userManager;
            userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        [HttpPost]
        public IActionResult Insert(UserQuestionHistoryDTO userQuestionHistoryDTO)
        {
            if (User != null && User.Identity != null && User.Identity.IsAuthenticated)
            {
                userQuestionHistoryDTO.UserId = userId;
                _userQuestionHistoryApplication.Insert(userQuestionHistoryDTO);
                return Ok(new { Sucesso = true });
            }
            return Unauthorized();
        }
        [HttpPut]
        public IActionResult Update(UserQuestionHistoryDTO userQuestionHistoryDTO)
        {
            _userQuestionHistoryApplication.Update(userQuestionHistoryDTO);
            return Ok(new { Sucesso = true });
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return NotFound();

            _userQuestionHistoryApplication.Delete(id);
            return Ok(new { Sucesso = true });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userQuestionHistoryApplication.GetAll());
        }

        [HttpGet("user-score")]
        public IActionResult GetUserScore()
        {
            if (User != null && User.Identity != null && User.Identity.IsAuthenticated)
            {
                return Ok(_userQuestionHistoryApplication.GetUserScore(userId));
            }
            else
                return Unauthorized();
        }

        [HttpGet("users-ranking/{quantity:int}")]
        public IActionResult GetUsersRanking(int quantity)
        {
            return Ok(_userQuestionHistoryApplication.GetUsersRanking(quantity));
        }
    }
}
