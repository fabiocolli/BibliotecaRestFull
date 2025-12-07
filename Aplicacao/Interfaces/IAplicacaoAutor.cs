using Dominio.Entidades;

namespace Aplicacao.Interfaces
{
    public interface IAplicacaoAutor : IAplicacaoGenerica<Autor>
    {
        Task<IList<Titulo>> ObterTitulosPeloAutor(int idAutor);
    }
}
