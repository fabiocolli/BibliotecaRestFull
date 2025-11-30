using Dominio.Entidades;
using Dominio.Interfaces;
using InfraEstrutura.Context;

namespace InfraEstrutura.Repositorios
{
    public class RepositorioPessoa : RepositorioGenerico<Pessoa>, IPessoa
    {
        public RepositorioPessoa(Contexto contexto) : base(contexto)
        {
        }
    }
}
