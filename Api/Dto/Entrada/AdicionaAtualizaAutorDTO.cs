using System.ComponentModel.DataAnnotations;

namespace Api.Dto.Entrada
{
    public class AdicionaAtualizaAutorDTO
    {
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
    }
}