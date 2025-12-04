using Dominio.Entidades;

namespace Dominio.Interfaces
{
    public interface IExemplar : IGenerica<Exemplar>
    {
        Task<IList<Exemplar>> ListarTodos();
        Task<Exemplar> BuscarPorIdComTitutlo(int id);
    }
}
