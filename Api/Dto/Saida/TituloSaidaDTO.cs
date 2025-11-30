using Dominio.Entidades;

namespace Api.Dto.Saida
{
    public class TituloSaidaDTO
    {
        public int Id { get; set; }
        public string DescricaoDoTitulo { get; set; }
        public List<Autor> Autores { get; set; } = new List<Autor>();
    }
}