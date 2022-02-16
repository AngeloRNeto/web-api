using WebApi.Domain.Models;
using WebApi.Domain.Repositories;

namespace WebApi.Entity.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        private readonly WebContext context;
        public ProdutoRepository(WebContext context) : base(context)
        {
            this.context = context;
        }
    }
}
