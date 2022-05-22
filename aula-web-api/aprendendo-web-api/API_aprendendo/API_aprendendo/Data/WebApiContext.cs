using API_aprendendo.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_aprendendo.Data
{
    /*Entity Framework: mapeia as nossas classes para criar um banco*/
    /*Meio de campo entre a aplicação e o banco de dados*/
    public class WebApiContext : DbContext
    {
        /*'options': serve para mandar o banco que vamos utilizar e a string de conexão deste banco*/
        public WebApiContext(DbContextOptions<WebApiContext> options):base(options)
        {

        }
        /*Criar uma tabela no banco do tipo Usuarios com as propriedades
         que estão na tabela*/
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
