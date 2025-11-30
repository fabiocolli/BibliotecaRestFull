using Api.Dto.Entrada;
using Api.Dto.Saida;
using Aplicacao.Interfaces;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IAplicaoPessoa _servicoPessoa;

        public PessoaController(IAplicaoPessoa servicoPessoa)
        {
            _servicoPessoa = servicoPessoa;
        }

        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] AdicionaAtualizaPessoaDTO pessoa)
        {
            if (pessoa == null ||
                string.IsNullOrWhiteSpace(pessoa.Nome) ||
                string.IsNullOrWhiteSpace(pessoa.Sobrenome) ||
                pessoa.Nascimento == default)
            {
                return BadRequest("Dados de entrada inválidos.");
            }

            var novaPessoa = Pessoa.Novo(
                pessoa.Nome,
                pessoa.Sobrenome,
                pessoa.Nascimento);

            var resultado = await _servicoPessoa.Adicionar(novaPessoa);

            return Created(string.Empty, resultado);
        }

        [Produces("application/json")]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Atualizar([FromRoute] int id,
            [FromBody] AdicionaAtualizaPessoaDTO pessoa)
        {
            if (pessoa == null ||
                string.IsNullOrWhiteSpace(pessoa.Nome) ||
                string.IsNullOrWhiteSpace(pessoa.Sobrenome) ||
                pessoa.Nascimento == default)
            {
                return BadRequest("Dados de entrada inválidos.");
            }

            var pessoaPraAtualizar = await _servicoPessoa.BuscarPorId(id);

            pessoaPraAtualizar.Nome = pessoa.Nome;
            pessoaPraAtualizar.Sobrenome = pessoa.Sobrenome;
            pessoaPraAtualizar.Nascimento = pessoa.Nascimento;

            await _servicoPessoa.Atualizar(pessoaPraAtualizar);

            return NoContent();
        }

        [Produces("application/json")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Excluir([FromRoute] int id)
        {
            var pessoaPraExcluir = await _servicoPessoa.BuscarPorId(id);

            await _servicoPessoa.Excluir(pessoaPraExcluir);

            return NoContent();
        }

        [Produces("application/json")]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> BuscarPorId([FromRoute] int id)
        {
            var resultado = await _servicoPessoa.BuscarPorId(id);

            return Ok(new PessoaSaidaDTO
            {
                Id = resultado.Id,
                Nome = resultado.Nome,
                Sobrenome = resultado.Sobrenome,
                Nascimento = resultado.Nascimento
            });
        }

        [Produces("application/json")]
        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var resultado = await _servicoPessoa.Listar();

            return Ok(resultado.Select(p => new PessoaSaidaDTO
            {
                Id = p.Id,
                Nome = p.Nome,
                Sobrenome = p.Sobrenome,
                Nascimento = p.Nascimento
            }));
        }
    }
}
