using Aplicacao.Interfaces;
using Dominio.Entidades;
using Dominio.Interfaces;

namespace Aplicacao.Servicos
{
    public class ServicoTitutlo : IAplicacaoTitulo
    {
        private readonly ITitulo _repositorioTitulo;

        public ServicoTitutlo(ITitulo repositorioTitulo)
        {
            _repositorioTitulo = repositorioTitulo;
        }

        public async Task<Titulo> Adicionar(Titulo objeto)
        {
            return await _repositorioTitulo.Adicionar(objeto);
        }

        public async Task<Titulo> Atualizar(Titulo objeto)
        {
            return await _repositorioTitulo.Atualizar(objeto);
        }

        public async Task<Titulo> BuscarPorId(int id)
        {
            return await _repositorioTitulo.BuscarPorId(id);
        }

        public async Task<Titulo> Excluir(Titulo objeto)
        {
            return await _repositorioTitulo.Excluir(objeto);
        }

        public async Task<IList<Titulo>> Listar()
        {
            return await _repositorioTitulo.Listar();
        }
    }
}
