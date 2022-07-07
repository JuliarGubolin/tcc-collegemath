using CollegeMath.Application.DTO;
using CollegeMath.Application.Interfaces;
using CollegeMath.Infra.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollegeMath.Controllers
{
    //[Authorize]
    //[Route("api/[controller]")]
    //[ApiController]
    //public class UsersController : ControllerBase
    //{
    //    private readonly IUserApplication _userApplication;

    //    public UsersController(IUserApplication userApplication)
    //    {
    //        _userApplication = userApplication;
    //    }
    //    [HttpPost]
    //    public IActionResult Insert(UsuarioDTO usuarioDTO)
    //    {
    //        _userApplication.Insert(usuarioDTO);
    //        return Ok(new { Sucesso = true });
    //    }
    //    [HttpPut]
    //    public IActionResult Update(UsuarioDTO usuarioDTO)
    //    {
    //        _userApplication.Update(usuarioDTO);
    //        return Ok(new { Sucesso = true });
    //    }
    //    [HttpDelete]
    //    public IActionResult Delete(int Id)
    //    {
    //        return Ok();
    //    }
    //    [HttpGet]
    //    public IActionResult GetAll(UsuarioDTO usuarioDTO)
    //    {
    //        return Ok(_userApplication.GetAll());
    //    }
    //    [HttpGet("Details", Name ="Details")]
    //    public IActionResult GetById(int id)
    //    {
    //        return Ok();
    //    }

    //    [HttpGet("UserHistory", Name = "UserHistory")]
    //    public IActionResult GetUserHistory()
    //    {
    //        return Ok();
    //    }
    //}
}
