using Dominio.Entidades;
using Dominio.Interfaces;
using InfraEstrutura.Context;

namespace InfraEstrutura.Repositorios
{
    public class RepositorioTitulo : RepositorioGenerico<Titulo>, ITitulo
    {
        public RepositorioTitulo(Contexto contexto) : base(contexto)
        {
        }
    }
}
