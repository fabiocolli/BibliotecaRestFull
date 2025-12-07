using Dominio.Entidades;
using Dominio.Interfaces;
using InfraEstrutura.Context;
using Microsoft.EntityFrameworkCore;

namespace InfraEstrutura.Repositorios
{
    public class RepositorioAutor : RepositorioGenerico<Autor>, IAutor
    {
        public RepositorioAutor(Contexto contexto) : base(contexto)
        {
        }
        public async Task<IList<Titulo>> ObterTitulosPeloAutor(int idAutor)
        {
            var autor = await _contexto.Autores.FindAsync(idAutor);

            return await
                _contexto.Titulos
                    .Where(t => t.Autores.Contains(autor))
                    .ToListAsync();
        }
    }
}
