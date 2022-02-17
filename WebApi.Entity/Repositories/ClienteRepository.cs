using WebApi.Domain.Models;
using WebApi.Domain.Repositories;

namespace WebApi.Entity.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        private readonly WebContext context;
        public ClienteRepository(WebContext context) : base(context)
        {
            this.context = context;
        }

        public override int Insert(Cliente entity)
        {
            if (entity.endereco != null)
            {
                context.Add(entity.endereco);
                context.SaveChanges();
            }

            return base.Insert(entity);
        }
    }
}
