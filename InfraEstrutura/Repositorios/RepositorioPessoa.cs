using Dominio.Entidades;
using Dominio.Interfaces;
using InfraEstrutura.Context;
using Microsoft.EntityFrameworkCore;

namespace InfraEstrutura.Repositorios
{
    public class RepositorioPessoa : RepositorioGenerico<Pessoa>, IPessoa
    {
        public RepositorioPessoa(Contexto contexto) : base(contexto)
        {
        }

        public async Task<IList<Emprestimo>> ObterEmprestimosPelaPessoa(int idPessoa)
        {
            return await _contexto.Emprestimos
                .Include(e => e.Pessoa)
                .Where(e => e.Pessoa.Id == idPessoa)
                .ToListAsync();
        }
    }
}
