using Dominio.Enumerados;

namespace Api.Dto.Saida
{
    public class ExemplarSaidaDTO
    {
        public int Id { get; set; }
        public DateTime DataDeAquisicao { get; set; }
        public int TituloId { get; set; }
        public string TituloDescricao { get; set; }
        public StatusExemplar StatusExemplar { get; set; }
    }
}