using WebApi.Domain.Models;
using WebApi.Domain.Repositories;

namespace WebApi.Entity.Repositories
{
    public class EnderecoRepository : BaseRepository<Endereco>, IEnderecoRepository
    {
        private readonly WebContext context;
        public EnderecoRepository(WebContext context) : base(context)
        {
            this.context = context;
        }
    }
}
