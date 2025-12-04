namespace Dominio.Entidades
{
    public class Autor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public ICollection<Titulo> Titulos { get; set; } = new List<Titulo>();

        public static Autor Novo(string nome, DateTime nascimento)
        {
            return new Autor
            {
                Nome = nome,
                Nascimento = nascimento
            };
        }
    }
}
