using Dominio.Entidades;

namespace Aplicacao.Interfaces
{
    public interface IAplicacaoEmprestimo : IAplicacaoGenerica<Emprestimo>
    {
        Task<IList<Emprestimo>> ObterEmprestimosPorPeriodo(DateTime dataInicio, DateTime dataFim);
    }
}
