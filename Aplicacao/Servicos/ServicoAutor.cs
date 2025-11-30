using Aplicacao.Interfaces;
using Dominio.Entidades;
using Dominio.Interfaces;

namespace Aplicacao.Servicos
{
    public class ServicoAutor : IAplicacaoAutor
    {
        private readonly IAutor _repositorioAutor;

        public ServicoAutor(IAutor repositorioAutor)
        {
            _repositorioAutor = repositorioAutor;
        }

        public async Task<Autor> Adicionar(Autor objeto)
        {
            return await _repositorioAutor.Adicionar(objeto);
        }

        public async Task<Autor> Atualizar(Autor objeto)
        {
            return await _repositorioAutor.Atualizar(objeto);
        }

        public async Task<Autor> BuscarPorId(int id)
        {
            return await _repositorioAutor.BuscarPorId(id);
        }

        public async Task<Autor> Excluir(Autor objeto)
        {
            return await _repositorioAutor.Excluir(objeto);
        }

        public async Task<IList<Autor>> Listar()
        {
            return await _repositorioAutor.Listar();
        }
    }
}
