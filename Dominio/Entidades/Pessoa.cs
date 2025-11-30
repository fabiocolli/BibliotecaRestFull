namespace Dominio.Entidades
{
	public class Pessoa
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Sobrenome { get; set; }
		public DateTime Nascimento { get; set; }
		public ICollection<Emprestimo> Emprestimos { get; set; }
	}
}
