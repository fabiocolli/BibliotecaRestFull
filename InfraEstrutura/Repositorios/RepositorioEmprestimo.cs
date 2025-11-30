using Dominio.Entidades;
using Dominio.Interfaces;
using InfraEstrutura.Context;

namespace InfraEstrutura.Repositorios
{
    public class RepositorioEmprestimo : RepositorioGenerico<Emprestimo>, IEmprestimo
    {
        public RepositorioEmprestimo(Contexto contexto) : base(contexto)
        {
        }
    }
}
