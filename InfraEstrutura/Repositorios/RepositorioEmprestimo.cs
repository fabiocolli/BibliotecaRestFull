using Dominio.Entidades;
using Dominio.Interfaces;
using InfraEstrutura.Context;
using Microsoft.EntityFrameworkCore;

namespace InfraEstrutura.Repositorios
{
    public class RepositorioEmprestimo : RepositorioGenerico<Emprestimo>, IEmprestimo
    {
        public RepositorioEmprestimo(Contexto contexto) : base(contexto)
        {
        }

        public async Task<IList<Emprestimo>> ObterEmprestimosPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            return await _contexto.Emprestimos
                .Include(e => e.Pessoa)
                .Include(e => e.Exemplares)
                .ThenInclude(e => e.Titulo)
                .Where(e => e.DataDoEmprestimo >= dataInicio && e.DataDoEmprestimo <= dataFim)
                .ToListAsync();
        }
    }
}
