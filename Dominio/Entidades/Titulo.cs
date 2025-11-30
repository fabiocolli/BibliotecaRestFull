namespace Dominio.Entidades
{
	public class Titulo
	{
		public int Id { get; set; }
		public string DescricaoDoTitulo { get; set; }
		public int IdAutor { get; set; }
		public ICollection<Autor> Autores { get; set; } = new List<Autor>();
	}
}

