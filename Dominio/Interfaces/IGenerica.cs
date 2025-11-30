namespace Dominio.Interfaces
{
    public interface IGenerica<T> where T : class
    {
        Task<T> Adicionar(T objeto);
        Task<T> Atualizar(T objeto);
        Task<T> Excluir(T objeto);
        Task<T> BuscarPorId(int id);
        Task<IList<T>> Listar();
    }
}
