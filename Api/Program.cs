using Aplicacao.Servicos;
using Dominio.Interfaces;
using InfraEstrutura.Context;
using InfraEstrutura.Repositorios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Contexto>(c =>
    c.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IGenerica<>), typeof(RepositorioGenerico<>));
builder.Services.AddScoped<IPessoa, RepositorioPessoa>();
builder.Services.AddScoped<IAutor, RepositorioAutor>();
builder.Services.AddScoped<IEmprestimo, RepositorioEmprestimo>();
builder.Services.AddScoped<IExemplar, RepositorioExemplar>();
builder.Services.AddScoped<ITitulo, RepositorioTitulo>();
builder.Services.AddScoped<ServicoPessoa>();
builder.Services.AddScoped<ServicoTitutlo>();
builder.Services.AddScoped<ServicoExemplar>();
builder.Services.AddScoped<ServicoEmprestimo>();
builder.Services.AddScoped<ServicoAutor>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
