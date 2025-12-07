using Aplicacao.Interfaces;
using Dominio.Entidades;
using Dominio.Interfaces;

namespace Aplicacao.Servicos
{
    public class ServicoPessoa : IAplicaoPessoa
    {
        private readonly IPessoa _repositorioPessoa;

        public ServicoPessoa(IPessoa repositorioPessoa)
        {
            _repositorioPessoa = repositorioPessoa;
        }

        public async Task<Pessoa> Adicionar(Pessoa objeto)
        {
            return await _repositorioPessoa.Adicionar(objeto);
        }

        public async Task<Pessoa> Atualizar(Pessoa objeto)
        {
            return await _repositorioPessoa.Atualizar(objeto);
        }

        public async Task<Pessoa> BuscarPorId(int id)
        {
            return await _repositorioPessoa.BuscarPorId(id);
        }

        public async Task<Pessoa> Excluir(Pessoa objeto)
        {
            return await _repositorioPessoa.Excluir(objeto);
        }

        public async Task<IList<Pessoa>> Listar()
        {
            return await _repositorioPessoa.Listar();
        }

        public async Task<IList<Emprestimo>> ObterEmprestimosPelaPessoa(int idPessoa)
        {
            return await _repositorioPessoa.ObterEmprestimosPelaPessoa(idPessoa);
        }
    }
}
