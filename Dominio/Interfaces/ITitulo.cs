using Dominio.Entidades;

namespace Dominio.Interfaces
{
    public interface ITitulo : IGenerica<Titulo>
    {
        Task<IList<Exemplar>> ObterExemplaresPeloTitulo(int idTitulo);
    }
}
