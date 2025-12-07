using Dominio.Entidades;

namespace Dominio.Interfaces
{
    public interface IAutor : IGenerica<Autor>
    {
        Task<IList<Titulo>> ObterTitulosPeloAutor(int idAutor);
    }
}
