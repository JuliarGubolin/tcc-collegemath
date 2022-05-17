using JuliaAulaWebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JuliaAulaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var produtos = new List<Produto>();
            produtos.Add(new Produto
            {
                Id = 1,
                Nome = "Mouse",
                Marca = "Dell"
            });
            produtos.Add(new Produto
            {
                Id = 2,
                Nome = "Teclado",
                Marca = "Dell"
            });
            produtos.Add(new Produto
            {
                Id = 3,
                Nome = "Monitor",
                Marca = "Dell"
            });
            return Ok(produtos);
        }

        [HttpPost]
        public IActionResult Insert(Produto produto) 
        {
            var produtoTeste = produto;
            return Ok(produtoTeste);
        }

        [HttpPut]
        public IActionResult Update(Produto produto)
        {
            var produtoTeste = produto;
            return Ok(produtoTeste);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            //Ficaria a implementação da exclusão
            return Ok(id);
        }

        [HttpGet("Details", Name = "Details")]
        public IActionResult GetById(int id) 
        {
            var produto = new Produto
            {
                Id = 1,
                Marca = "Teste",
                Nome = "Teste"
            };
            return Ok(produto);
        }
    }
}