using Dominio.Entidades;
using Dominio.Interfaces;
using InfraEstrutura.Context;

namespace InfraEstrutura.Repositorios
{
    public class RepositorioAutor : RepositorioGenerico<Autor>, IAutor
    {
        public RepositorioAutor(Contexto contexto) : base(contexto)
        {
        }
    }
}
