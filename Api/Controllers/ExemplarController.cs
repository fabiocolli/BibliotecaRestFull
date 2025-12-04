using Api.Dto.Entrada;
using Api.Dto.Saida;
using Aplicacao.Interfaces;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExemplarController : ControllerBase
    {
        private readonly IAplicacaoExemplar _servicoExemplar;

        public ExemplarController(IAplicacaoExemplar servicoExemplar)
        {
            _servicoExemplar = servicoExemplar;
        }

        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] AdicionaAtualizaExemplarDTO exemplar)
        {
            if (exemplar == null ||
                exemplar.TituloId <= 0 ||
                exemplar.DataDeAquisicao == default)
            {
                return BadRequest("Dados de entrada inválidos.");
            }

            var novoExemplar = new Exemplar
            {
                DataDeAquisicao = exemplar.DataDeAquisicao,
                TituloId = exemplar.TituloId,
                StatusExemplar = exemplar.StatusExemplar,
                NumeroDoExemplar = exemplar.NumeroDoExemplar
            };

            var resultado = await _servicoExemplar.Adicionar(novoExemplar);

            return Created(string.Empty, resultado);
        }

        [Produces("application/json")]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Atualizar([FromRoute] int id,
            [FromBody] AdicionaAtualizaExemplarDTO exemplar)
        {
            if (exemplar == null ||
                exemplar.TituloId <= 0 ||
                exemplar.DataDeAquisicao == default)
            {
                return BadRequest("Dados de entrada inválidos.");
            }

            var exemplarPraAtualizar = await _servicoExemplar.BuscarPorId(id);

            exemplarPraAtualizar.DataDeAquisicao = exemplar.DataDeAquisicao;
            exemplarPraAtualizar.TituloId = exemplar.TituloId;
            exemplarPraAtualizar.StatusExemplar = exemplar.StatusExemplar;
            exemplarPraAtualizar.NumeroDoExemplar = exemplar.NumeroDoExemplar;

            await _servicoExemplar.Atualizar(exemplarPraAtualizar);

            return NoContent();
        }

        [Produces("application/json")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Excluir([FromRoute] int id)
        {
            var exemplarPraExcluir = await _servicoExemplar.BuscarPorId(id);

            await _servicoExemplar.Excluir(exemplarPraExcluir);

            return NoContent();
        }

        [Produces("application/json")]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> BuscarPorId([FromRoute] int id)
        {
            var resultado = await _servicoExemplar.BuscarPorId(id);

            return Ok(new ExemplarSaidaDTO
            {
                Id = resultado.Id,
                DataDeAquisicao = resultado.DataDeAquisicao,
                TituloId = resultado.TituloId,
                StatusExemplar = resultado.StatusExemplar,
                TituloDescricao = resultado.Titulo.DescricaoDoTitulo
            });
        }

        [Produces("application/json")]
        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var resultado = await _servicoExemplar.Listar();

            return Ok(resultado.Select(e => new ExemplarSaidaDTO
            {
                Id = e.Id,
                DataDeAquisicao = e.DataDeAquisicao,
                TituloId = e.TituloId,
                StatusExemplar = e.StatusExemplar,
                TituloDescricao = e.Titulo.DescricaoDoTitulo
            }));
        }
    }
}