using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Models;

namespace WebApi.Entity
{
    public class WebContext : DbContext
    {
        public WebContext(DbContextOptions<WebContext> options) : base(options)
        {
          
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql(@"Host=localhost;Database=webapi;Username=postgres;Password=admin;Port=5432");
        //}

        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<ClienteDados> cliente_dados { get; set; }
        public DbSet<Endereco> enderecos { get; set; }
        public DbSet<Produto> produtos { get; set; }
        public DbSet<Carrinho> carrinhos { get; set; }

    }
}