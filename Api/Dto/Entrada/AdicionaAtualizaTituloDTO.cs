namespace Api.Dto.Entrada
{
    public class AdicionaAtualizaTituloDTO
    {
        public string DescricaoDoTitulo { get; set; }
        public List<AdicionaAutorAoTitulo> Autores { get; set; } = new List<AdicionaAutorAoTitulo>();
    }
}