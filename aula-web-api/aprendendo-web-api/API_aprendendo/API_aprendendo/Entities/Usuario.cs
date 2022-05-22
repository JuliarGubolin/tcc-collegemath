namespace API_aprendendo.Entities
{
    //Quando temos uma classe no Entity, possivelmente ela será uma tabela no banco de dados
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
