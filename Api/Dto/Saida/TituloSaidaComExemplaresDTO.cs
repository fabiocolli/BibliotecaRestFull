namespace Api.Dto.Saida
{
    public class TituloSaidaComExemplaresDTO
    {
        public int Id { get; set; }
        public string DescricaoDoTitulo { get; set; }
        public IList<AutorSimplesDTO> Autores { get; set; } = new List<AutorSimplesDTO>();
        public IList<ExemplarSemTituloSaidaDTO> Exemplares { get; set; } = new List<ExemplarSemTituloSaidaDTO>();
    }
}
