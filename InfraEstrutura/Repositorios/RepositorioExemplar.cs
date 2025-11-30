using Dominio.Entidades;
using Dominio.Interfaces;
using InfraEstrutura.Context;

namespace InfraEstrutura.Repositorios
{
    public class RepositorioExemplar : RepositorioGenerico<Exemplar>, IExemplar
    {
        public RepositorioExemplar(Contexto contexto) : base(contexto)
        {
        }
    }
}
