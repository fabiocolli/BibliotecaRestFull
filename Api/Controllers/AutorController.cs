using Api.Dto.Entrada;
using Api.Dto.Saida;
using Aplicacao.Interfaces;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutorController : ControllerBase
    {
        private readonly IAplicacaoAutor _servicoAutor;

        public AutorController(IAplicacaoAutor servicoAutor)
        {
            _servicoAutor = servicoAutor;
        }

        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] AdicionaAtualizaAutorDTO autor)
        {
            if (autor == null ||
                string.IsNullOrWhiteSpace(autor.Nome) ||
                autor.Nascimento == default)
            {
                return BadRequest("Dados de entrada inválidos.");
            }

            var novoAutor = Autor.Novo(
                autor.Nome,
                autor.Nascimento);

            var resultado = await _servicoAutor.Adicionar(novoAutor);

            return Created(string.Empty, resultado);
        }

        [Produces("application/json")]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Atualizar([FromRoute] int id,
            [FromBody] AdicionaAtualizaAutorDTO autor)
        {
            if (autor == null ||
                string.IsNullOrWhiteSpace(autor.Nome) ||
                autor.Nascimento == default)
            {
                return BadRequest("Dados de entrada inválidos.");
            }

            var autorPraAtualizar = await _servicoAutor.BuscarPorId(id);

            autorPraAtualizar.Nome = autor.Nome;
            autorPraAtualizar.Nascimento = autor.Nascimento;

            await _servicoAutor.Atualizar(autorPraAtualizar);

            return NoContent();
        }

        [Produces("application/json")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Excluir([FromRoute] int id)
        {
            var autorPraExcluir = await _servicoAutor.BuscarPorId(id);

            await _servicoAutor.Excluir(autorPraExcluir);

            return NoContent();
        }

        [Produces("application/json")]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> BuscarPorId([FromRoute] int id)
        {
            var resultado = await _servicoAutor.BuscarPorId(id);

            return Ok(new AutorSaidaDTO
            {
                Id = resultado.Id,
                Nome = resultado.Nome,
                Nascimento = resultado.Nascimento
            });
        }

        [Produces("application/json")]
        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var resultado = await _servicoAutor.Listar();

            return Ok(resultado.Select(a => new AutorSaidaDTO
            {
                Id = a.Id,
                Nome = a.Nome,
                Nascimento = a.Nascimento
            }));
        }
    }
}