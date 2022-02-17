using WebApi.Domain.Models;
using WebApi.Domain.Repositories;
using WebApi.Domain.Services;

namespace WebApi.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        private readonly IClienteDadosRepository _clienteDadosRepository;
        public ClienteService(IClienteRepository repository, IClienteDadosRepository clienteDadosRepository)
        {
            _repository = repository;
            _clienteDadosRepository = clienteDadosRepository;
        }

        public void Delete(int id)
        {
            _repository.Delete(GetById(id));
        }

        public List<Cliente> GetAll<TEntity>()
        {
            var clientes = _repository.GetAll<Cliente>("endereco");

            clientes.ForEach(e =>
            {
                e.cliente_dados = _clienteDadosRepository.GetClienteDados(e.id);
                e.endereco_id = e.endereco.id;
            });

            return clientes;
        }

        public Cliente GetById(int id)
        {
            var cart = _repository.GetById(id, "cliente_dados", "endereco");
            cart.endereco_id = cart.endereco?.id == null ? 0 : cart.endereco.id;

            return cart;
        }

        public int Insert(Cliente entity)
        {
            return _repository.Insert(entity);
        }

        public int Update(Cliente entity)
        {
            return _repository.Update(entity);
        }
    }
}