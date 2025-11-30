namespace Api.Dto.Saida
{
    public class PessoaSaidaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime Nascimento { get; set; }
        public int Idade => DateTime.Now.Year - Nascimento.Year;
    }
}
