using Api.Dto.Saida;
using Aplicacao.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmprestimoController : ControllerBase
    {
        private readonly IAplicacaoEmprestimo _servicoEmprestimo;
        public EmprestimoController(IAplicacaoEmprestimo servicoEmprestimo)
        {
            _servicoEmprestimo = servicoEmprestimo;
        }

        [Produces("application/json")]
        [HttpGet()]
        public async Task<IActionResult> ObterEmprestimosPorPeriodo([FromQuery] DateTime dataInicio,
           [FromQuery] DateTime dataFim)
        {
            var resultado = await _servicoEmprestimo.ObterEmprestimosPorPeriodo(dataInicio, dataFim);

            return Ok(resultado.Select(e => new EmprestimoSaidaPorPeriodoDTO
            {
                Id = e.Id,
                DataDoEmprestimo = e.DataDoEmprestimo,
                DataDeDevolucao = e.DataDeDevolucao,
                NomeDaPessoa = $"{e.Pessoa.Nome} {e.Pessoa.Sobrenome}",
                Exemplares = e.Exemplares.Select(ex => new ExemplarSaidaDTO
                {
                    Id = ex.Id,
                    DataDeAquisicao = ex.DataDeAquisicao,
                    TituloId = ex.TituloId,
                    StatusExemplar = ex.StatusExemplar.ToString(),
                    TituloDescricao = ex.Titulo.DescricaoDoTitulo
                }).ToList()
            }));
        }

        [Produces("application/json")]
        [HttpGet("abertos")]
        public async Task<IActionResult> ObterEmprestimosEmAbertoPorPeriodo([FromQuery] DateTime dataInicio,
           [FromQuery] DateTime dataFim)
        {
            var resultado = await _servicoEmprestimo.ObterEmprestimosEmAbertoPorPeriodo(dataInicio, dataFim);

            return Ok(resultado.Select(e => new EmprestimoSaidaPorPeriodoDTO
            {
                Id = e.Id,
                DataDoEmprestimo = e.DataDoEmprestimo,
                DataDeDevolucao = e.DataDeDevolucao,
                NomeDaPessoa = $"{e.Pessoa.Nome} {e.Pessoa.Sobrenome}",
                Exemplares = e.Exemplares.Select(ex => new ExemplarSaidaDTO
                {
                    Id = ex.Id,
                    DataDeAquisicao = ex.DataDeAquisicao,
                    TituloId = ex.TituloId,
                    StatusExemplar = ex.StatusExemplar.ToString(),
                    TituloDescricao = ex.Titulo.DescricaoDoTitulo
                }).ToList()
            }));
        }
    }
}
