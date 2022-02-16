using WebApi.Domain.Models;
using WebApi.Domain.Repositories;

namespace WebApi.Entity.Repositories
{
    public class CarrinhoRepository : BaseRepository<Carrinho> , ICarrinhoRepository
    {
        private readonly WebContext context;
        public CarrinhoRepository(WebContext context) : base(context)
        {
            this.context = context;
        }
    }
}
