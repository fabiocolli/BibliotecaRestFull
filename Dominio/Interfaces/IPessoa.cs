using Dominio.Entidades;

namespace Dominio.Interfaces
{
    public interface IPessoa : IGenerica<Pessoa>
    {
        Task<IList<Emprestimo>> ObterEmprestimosPelaPessoa(int idPessoa);
    }
}
