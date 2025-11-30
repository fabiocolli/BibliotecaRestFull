using Dominio.Enumerados;

namespace Dominio.Entidades
{
    public class Exemplar
    {
        public int Id { get; set; }
        public DateTime DataDeAquisicao { get; set; }
        public int TituloId { get; set; }
        public StatusExemplar StatusExemplar { get; set; }
        public Titulo Titulo { get; set; }
    }
}
