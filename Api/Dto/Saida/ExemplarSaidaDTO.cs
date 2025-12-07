namespace Api.Dto.Saida
{
    public class ExemplarSaidaDTO
    {
        public int Id { get; set; }
        public DateTime DataDeAquisicao { get; set; }
        public int TituloId { get; set; }
        public string TituloDescricao { get; set; }
        public string StatusExemplar { get; set; }
    }
}