using Dominio.Entidades;
using Dominio.Interfaces;
using InfraEstrutura.Context;
using Microsoft.EntityFrameworkCore;

namespace InfraEstrutura.Repositorios
{
    public class RepositorioExemplar : RepositorioGenerico<Exemplar>, IExemplar
    {
        public RepositorioExemplar(Contexto contexto) : base(contexto)
        {
        }

        public async Task<Exemplar> BuscarPorIdComTitutlo(int id)
        {
            var exemplarComTitulo = await _contexto.Exemplares
                .Include(e => e.Titulo)
                .FirstOrDefaultAsync(e => e.Id == id);

            return exemplarComTitulo;
        }

        public async Task<IList<Exemplar>> ListarTodos()
        {
            var todosExemplares = await _contexto.Exemplares
                .Include(e => e.Titulo)
                .ToListAsync();

            return todosExemplares;
        }
    }
}
