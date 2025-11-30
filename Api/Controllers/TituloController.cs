using Api.Dto.Entrada;
using Api.Dto.Saida;
using Aplicacao.Interfaces;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TituloController : ControllerBase
    {
        private readonly IAplicacaoTitulo _servicoTitulo;

        public TituloController(IAplicacaoTitulo servicoTitulo)
        {
            _servicoTitulo = servicoTitulo;
        }

        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] AdicionaAtualizaTituloDTO titulo)
        {
            if (titulo is null ||
                string.IsNullOrWhiteSpace(titulo.DescricaoDoTitulo) ||
                !titulo.Autores.Any())
            {
                return BadRequest("Dados de entrada inválidos.");
            }

            var autores = titulo.Autores.Select(a => new Autor
            {
                Id = a.Id,
                Nome = a.Nome,
                Nascimento = a.Nascimento
            }).ToList();

            var novoTitulo = Titulo.Novo(titulo.DescricaoDoTitulo, autores);

            var resultado = await _servicoTitulo.Adicionar(novoTitulo);

            return Created(string.Empty, resultado);
        }

        [Produces("application/json")]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Atualizar([FromRoute] int id,
            [FromBody] AdicionaAtualizaTituloDTO titulo)
        {
            if (titulo is null ||
                string.IsNullOrWhiteSpace(titulo.DescricaoDoTitulo) ||
                !titulo.Autores.Any())
            {
                return BadRequest("Dados de entrada inválidos.");
            }

            var tituloPraAtualizar = await _servicoTitulo.BuscarPorId(id);

            tituloPraAtualizar.DescricaoDoTitulo = titulo.DescricaoDoTitulo;
            tituloPraAtualizar.Autores = titulo.Autores.Select(a => Autor.Novo(a.Nome, a.Nascimento)).ToList();

            await _servicoTitulo.Atualizar(tituloPraAtualizar);

            return NoContent();
        }

        [Produces("application/json")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Excluir([FromRoute] int id)
        {
            var tituloPraExcluir = await _servicoTitulo.BuscarPorId(id);

            await _servicoTitulo.Excluir(tituloPraExcluir);

            return NoContent();
        }

        [Produces("application/json")]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> BuscarPorId([FromRoute] int id)
        {
            var resultado = await _servicoTitulo.BuscarPorId(id);

            return Ok(new TituloSaidaDTO
            {
                Id = resultado.Id,
                DescricaoDoTitulo = resultado.DescricaoDoTitulo,
                Autores = resultado.Autores.ToList()
            });
        }

        [Produces("application/json")]
        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var resultado = await _servicoTitulo.Listar();

            return Ok(resultado.Select(t => new TituloSaidaDTO
            {
                Id = t.Id,
                DescricaoDoTitulo = t.DescricaoDoTitulo,
                Autores = t.Autores.ToList()
            }));
        }
    }
}