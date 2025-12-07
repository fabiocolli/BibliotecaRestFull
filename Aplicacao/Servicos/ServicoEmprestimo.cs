using Aplicacao.Interfaces;
using Dominio.Entidades;
using Dominio.Interfaces;

namespace Aplicacao.Servicos
{
    public class ServicoEmprestimo : IAplicacaoEmprestimo
    {
        private readonly IEmprestimo _repositorioEmprestimo;

        public ServicoEmprestimo(IEmprestimo repositorioEmprestimo)
        {
            _repositorioEmprestimo = repositorioEmprestimo;
        }

        public async Task<Emprestimo> Adicionar(Emprestimo objeto)
        {
            return await _repositorioEmprestimo.Adicionar(objeto);
        }

        public async Task<Emprestimo> Atualizar(Emprestimo objeto)
        {
            return await _repositorioEmprestimo.Atualizar(objeto);
        }

        public async Task<Emprestimo> BuscarPorId(int id)
        {
            return await _repositorioEmprestimo.BuscarPorId(id);
        }

        public async Task<Emprestimo> Excluir(Emprestimo objeto)
        {
            return await _repositorioEmprestimo.Excluir(objeto);
        }

        public async Task<IList<Emprestimo>> Listar()
        {
            return await _repositorioEmprestimo.Listar();
        }

        public async Task<IList<Emprestimo>> ObterEmprestimosPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            return await _repositorioEmprestimo.ObterEmprestimosPorPeriodo(dataInicio, dataFim);
        }
    }
}
