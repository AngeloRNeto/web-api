using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Models;
using WebApi.Domain.Repositories;

namespace WebApi.Entity.Repositories
{
    public class ClienteDadosRepository : BaseRepository<ClienteDados>, IClienteDadosRepository
    {
        private readonly WebContext context;
        public ClienteDadosRepository(WebContext context) : base(context)
        {
            this.context = context;
        }

        public List<ClienteDados> GetClienteDados(int id)
        {
            var clienteDados = context.cliente_dados
                .Include(e => e.cliente)
                .Where(e => e.cliente.id == id && e.situacao == Domain.Enums.ESituacao.Ativo).ToList();

            clienteDados.ForEach(e =>
            {
                e.cliente_id = e.cliente.id;
                e.cliente = null;
            });

            return clienteDados;
        }
    }
}
