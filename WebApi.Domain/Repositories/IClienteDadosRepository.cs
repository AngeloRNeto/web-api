using WebApi.Domain.Models;

namespace WebApi.Domain.Repositories
{
    public interface IClienteDadosRepository : IBaseRepository<ClienteDados>
    {
        List<ClienteDados> GetClienteDados(int cliente_id);
    }
}
