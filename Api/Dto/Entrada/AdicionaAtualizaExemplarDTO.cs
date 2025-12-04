using Dominio.Enumerados;

namespace Api.Dto.Entrada
{
    public class AdicionaAtualizaExemplarDTO
    {
        public DateTime DataDeAquisicao { get; set; }
        public int TituloId { get; set; }
        public int NumeroDoExemplar { get; set; }
        public StatusExemplar StatusExemplar { get; set; }
    }
}