using Aplicacao.Interfaces;
using Aplicacao.Servicos;
using Dominio.Interfaces;
using InfraEstrutura.Context;
using InfraEstrutura.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerUI;

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
builder.Services.AddScoped<IAplicaoPessoa, ServicoPessoa>();
builder.Services.AddScoped<IAplicacaoTitulo, ServicoTitutlo>();
builder.Services.AddScoped<IAplicacaoExemplar, ServicoExemplar>();
builder.Services.AddScoped<IAplicacaoEmprestimo, ServicoEmprestimo>();
builder.Services.AddScoped<IAplicacaoAutor, ServicoAutor>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(sg =>
{
    sg.SwaggerDoc("v1", new OpenApiInfo { Title = "Biblioteca", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.DefaultModelsExpandDepth(0);
        c.DocExpansion(DocExpansion.None);
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
