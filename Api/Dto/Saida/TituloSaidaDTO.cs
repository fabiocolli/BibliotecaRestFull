namespace Api.Dto.Saida
{
    public class TituloSaidaDTO
    {
        public int Id { get; set; }
        public string DescricaoDoTitulo { get; set; }
        public List<AutorSimplesDTO> Autores { get; set; } = new List<AutorSimplesDTO>();
    }
}