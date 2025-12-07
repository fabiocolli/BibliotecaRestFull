using Dominio.Entidades;

namespace Aplicacao.Interfaces
{
    public interface IAplicaoPessoa : IAplicacaoGenerica<Pessoa>
    {
        Task<IList<Emprestimo>> ObterEmprestimosPelaPessoa(int idPessoa);
    }
}
