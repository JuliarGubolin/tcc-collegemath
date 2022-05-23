using API_aprendendo.Data;
using API_aprendendo.DTO;
using API_aprendendo.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_aprendendo.Controllers
{
    //Rota no domínio para encontrar a API(boa prática)
    [Route("api/[controller]")]
    //Data notations: Neste caso, esta define que esta classe é uma API
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly WebApiContext _context;

        public UsuariosController(WebApiContext context)
        {
            _context = context;
        }
        //GET: retorna dados salvos em um banco
        [HttpGet]
        //Quando tivermos mais de um GET na mesma controller, precisamos dar um nome para ele
        //Chamando pelo Browser: https://localhost:7295/api/usuarios
        //Retorna um JSON
        public IActionResult GetAll()
        {
            //Aqui apenas fazemos um retorno do Status Code OK
            //Tipos de Status Code:
            /* - 404: não encontrado
               - 500: erro de servidor
               - 401: não autorizado
               - 200: ok*/
            var usuarios = _context.Usuarios.ToList();
            var usuariosDTO = usuarios.Select(item => new UsuarioDTO
            {
                Id = item.Id,
                Nome= item.Nome,
                Email = item.Email,
                Senha = item.Senha
            }).ToList();

            #region ListaEstatica Usuários
            //var usuarios = new List<Usuario>();
            //usuarios.Add(new Usuario
            //{
            //    Id = 1,
            //    Nome = "Julia Rodrigues Gubolin",
            //    Email = "julia.gubolin@gmail.com",
            //    Senha = "******"
            //});
            //usuarios.Add(new Usuario
            //{
            //    Id = 2,
            //    Nome = "Marcos Alberto Gubolin",
            //    Email = "marcos.gubolin@gmail.com",
            //    Senha = "******"
            //});
            //usuarios.Add(new Usuario
            //{
            //    Id = 3,
            //    Nome = "Daniel Abdalla",
            //    Email = "daniel.ab@gmail.com",
            //    Senha = "******"
            //});

            //return Ok(usuarios);
            #endregion
            return Ok(usuariosDTO);
        }
        [HttpPost]
        // Recebe um JSON com os dados para serem salvos
        //Usamos UsuarioDTO pois ele será o responsável por obter e enviar os dados
        //para a tela, para que a classe não faça isso e possamos separar responsabilidades

        public IActionResult Insert(UsuarioDTO usuarioDTO)
        {
            //var userTeste = usuario;
            var usuario = new Usuario
            {
                Nome = usuarioDTO.Nome,
                Email = usuarioDTO.Email,
                Senha = usuarioDTO.Senha
            };
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return Ok(usuario);
        }
        //Put para atualização
        [HttpPut]
        // Recebe um JSON com os dados para serem salvos
        public IActionResult Update(UsuarioDTO usuarioDTO)
        {
            //var userTeste = usuario;
            var usuarioAlterado = _context.Usuarios.Find(usuarioDTO.Id);
            //O usuário pode ser nulo
            if(usuarioAlterado == null)
            {
                return NotFound();
            }
            usuarioAlterado.Nome = usuarioDTO.Nome;
            usuarioAlterado.Email = usuarioDTO.Email;
            usuarioAlterado.Senha = usuarioDTO.Senha;
            _context.Usuarios.Update(usuarioAlterado);
            _context.SaveChanges();
            return Ok(usuarioAlterado);
        }
        [HttpDelete]
        // Recebe um JSON com os dados para serem salvos
        public IActionResult Delete(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
            return Ok("Usuario " + id + " excluido com sucesso.");
        }

        [HttpGet("Details", Name ="Details")]
        public IActionResult GetById(int id)
        {
            #region Usuario estatico
            //var usuario = new Usuario
            //{
            //    Id = 3,
            //    Nome = "Daniel Abdalla",
            //    Email = "daniel.ab@gmail.com",
            //    Senha = "******"
            //};
            #endregion
            //Mesma coisa quem: SELECT * FROM Usuario WHERE Id = {id}
            var usuario = _context.Usuarios.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            var usuarioDTO = new UsuarioDTO
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = usuario.Senha
            };
            return Ok(usuarioDTO);
        }
    }
}
