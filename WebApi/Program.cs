using Microsoft.EntityFrameworkCore;
using WebApi.Entity;
using WebApi.Domain.Services;
using WebApi.Service;
using WebApi.Domain.Repositories;
using WebApi.Entity.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(opts => opts.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

builder.Services.AddDbContext<WebContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("WebApi"))
);



//Services
builder.Services.AddTransient<IUsuarioService, UsuarioService>();
builder.Services.AddTransient<IProdutoService, ProdutoService>();
builder.Services.AddTransient<IClienteService, ClienteService>();
builder.Services.AddTransient<IEnderecoService, EnderecoService>();
builder.Services.AddTransient<ICarrinhoService, CarrinhoService>();

////Repository
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();
builder.Services.AddTransient<IClienteRepository, ClienteRepository>();
builder.Services.AddTransient<IClienteDadosRepository, ClienteDadosRepository>();
builder.Services.AddTransient<IEnderecoRepository, EnderecoRepository>();
builder.Services.AddTransient<ICarrinhoRepository, CarrinhoRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
