using Dominio.Entidades;

namespace Aplicacao.Interfaces
{
    public interface IAplicacaoTitulo : IAplicacaoGenerica<Titulo>
    {
        Task<IList<Exemplar>> ObterExemplaresPeloTitulo(int idTitulo);

    }
}
