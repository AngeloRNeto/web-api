using WebApi.Domain.Models;
using WebApi.Domain.Repositories;

namespace WebApi.Entity.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly WebContext context;
        public UsuarioRepository(WebContext context) : base(context)
        {
            this.context = context;
        }
    }
}
