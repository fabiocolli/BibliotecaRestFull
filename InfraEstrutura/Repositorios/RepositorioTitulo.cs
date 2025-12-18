using Dominio.Entidades;
using Dominio.Interfaces;
using InfraEstrutura.Context;
using Microsoft.EntityFrameworkCore;

namespace InfraEstrutura.Repositorios
{
    public class RepositorioTitulo : RepositorioGenerico<Titulo>, ITitulo
    {
        public RepositorioTitulo(Contexto contexto) : base(contexto)
        {
        }

        public async Task<IList<Exemplar>> ObterExemplaresPeloTitulo(int idTitulo)
        {
            return await _contexto.Exemplares
                .Include(e => e.Titulo)
                .Where(e => e.TituloId == idTitulo)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IList<Exemplar>> ObterTituloPorNomeAproximado(string nome)
        {
            return await _contexto.Exemplares
                .Include(e => e.Titulo)
                .ThenInclude(e => e.Autores)
                .Where(e => e.Titulo.DescricaoDoTitulo.Contains(nome))
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
