using Aplicacao.Interfaces;
using Dominio.Entidades;
using Dominio.Interfaces;

namespace Aplicacao.Servicos
{
    public class ServicoExemplar : IAplicacaoExemplar
    {
        private readonly IExemplar _repositorioExemplar;

        public ServicoExemplar(IExemplar repositorioExemplar)
        {
            _repositorioExemplar = repositorioExemplar;
        }

        public async Task<Exemplar> Adicionar(Exemplar objeto)
        {
            return await _repositorioExemplar.Adicionar(objeto);
        }

        public async Task<Exemplar> Atualizar(Exemplar objeto)
        {
            return await _repositorioExemplar.Atualizar(objeto);
        }

        public async Task<Exemplar> BuscarPorId(int id)
        {
            return await _repositorioExemplar.BuscarPorId(id);
        }

        public async Task<Exemplar> Excluir(Exemplar objeto)
        {
            return await _repositorioExemplar.Excluir(objeto);
        }

        public async Task<IList<Exemplar>> Listar()
        {
            return await _repositorioExemplar.Listar();
        }
    }
}
