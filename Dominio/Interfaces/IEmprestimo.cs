using Dominio.Entidades;

namespace Dominio.Interfaces
{
    public interface IEmprestimo : IGenerica<Emprestimo>
    {
        Task<IList<Emprestimo>> ObterEmprestimosPorPeriodo(DateTime dataInicio, DateTime dataFim);
        Task<IList<Emprestimo>> ObterEmprestimosEmAbertoPorPeriodo(DateTime dataInicio, DateTime dataFim);
    }
}
