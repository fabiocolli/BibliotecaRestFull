namespace Api.Dto.Saida
{
    public class EmprestimoSaidaDTO
    {
        public int Id { get; set; }
        public DateTime DataDoEmprestimo { get; set; }
        public DateTime? DataDeDevolucao { get; set; }
        public string SituacaoDoEmprestimo { get; set; }
        public IList<ExemplarSaidaDTO> Exemplares { get; set; } = new List<ExemplarSaidaDTO>();
    }
}
