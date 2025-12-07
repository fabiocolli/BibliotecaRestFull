using Api.Dto.Entrada;
using Api.Dto.Saida;
using Aplicacao.Interfaces;
using Dominio.Entidades;
using InfraEstrutura.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TituloController : ControllerBase
    {
        private readonly IAplicacaoTitulo _servicoTitulo;
        private readonly Contexto _contexto;

        public TituloController(IAplicacaoTitulo servicoTitulo, Contexto contexto)
        {
            _servicoTitulo = servicoTitulo;
            _contexto = contexto;
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

            var autoresSalvaNoTitulo = await _contexto.Autores
                .Where(a => autores.Select(au => au.Id).Contains(a.Id))
                .ToListAsync();

            var novoTitulo = Titulo.Novo(titulo.DescricaoDoTitulo, autoresSalvaNoTitulo);

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

            var autores = resultado.Autores.Select(a => new AutorSimplesDTO
            {
                Id = a.Id,
                Nome = a.Nome,
                Nascimento = a.Nascimento
            }).ToList();

            return Ok(new TituloSaidaDTO
            {
                Id = resultado.Id,
                DescricaoDoTitulo = resultado.DescricaoDoTitulo,
                Autores = autores
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
                Autores = t.Autores.Select(at => new AutorSimplesDTO
                {
                    Id = at.Id,
                    Nome = at.Nome,
                    Nascimento = at.Nascimento
                }).ToList()
            }));
        }

        [Produces("application/json")]
        [HttpGet("{idTitulo:int}/exemplares")]
        public async Task<IActionResult> ObterExemplaresPeloTitulo([FromRoute] int idTitulo)
        {
            var resultado = await _servicoTitulo.ObterExemplaresPeloTitulo(idTitulo);

            return Ok(resultado.Select(e => new ExemplarSaidaDTO
            {
                Id = e.Id,
                TituloId = e.TituloId,
                TituloDescricao = e.Titulo.DescricaoDoTitulo,
            }));
        }

    }
}