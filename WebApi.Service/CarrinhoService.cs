using WebApi.Domain.Models;
using WebApi.Domain.Repositories;
using WebApi.Domain.Services;

namespace WebApi.Service
{
    public class CarrinhoService : ICarrinhoService
    {
        private readonly ICarrinhoRepository _repository;
        public CarrinhoService(ICarrinhoRepository repository)
        {
            _repository = repository;
        }

        public void Delete(int id)
        {
            _repository.Delete(GetById(id));
        }

        public List<Carrinho> GetAll<TEntity>()
        {
            var carts = _repository.GetAll<Carrinho>("produto", "cliente");
            carts.ForEach(e =>
            {
                e.produto_id = e.produto.id;
                e.cliente_id = e.cliente.id;
            });

            return carts;
        }

        public Carrinho GetById(int id)
        {
            var cart = _repository.GetById(id, "produto", "cliente");
            cart.cliente_id = cart.cliente?.id == null ? 0 : cart.cliente.id;
            cart.produto_id = cart.produto?.id == null ? 0 : cart.produto.id;

            return cart;
        }

        public int Insert(Carrinho entity)
        {
            return _repository.Insert(entity);
        }

        public int Update(Carrinho entity)
        {
            return _repository.Update(entity);
        }
    }
}