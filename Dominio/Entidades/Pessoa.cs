namespace Dominio.Entidades
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime Nascimento { get; set; }
        public ICollection<Emprestimo> Emprestimos { get; set; }

        public static Pessoa Novo(string nome, string sobreNome, DateTime nascimento)
        {
            return new Pessoa
            {
                Nome = nome,
                Sobrenome = sobreNome,
                Nascimento = nascimento
            };
        }
    }
}
