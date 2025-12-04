namespace Dominio.Entidades
{
    public class Emprestimo
    {
        public int Id { get; set; }
        public Pessoa Pessoa { get; set; }
        public DateTime DataDoEmprestimo { get; set; }
        public DateTime DataDeDevolucao { get; set; }
        public ICollection<Exemplar> Exemplares { get; set; } = new List<Exemplar>();
    }
}
