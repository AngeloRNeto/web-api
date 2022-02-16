using WebApi.Domain.Models;
using WebApi.Domain.Repositories;
using WebApi.Domain.Services;

namespace WebApi.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;
        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public void Delete(int id)
        {
            _repository.Delete(GetById(id));
        }

        public List<Produto> GetAll<TEntity>()
        {
            var produtos = _repository.GetAll<Produto>();
            return produtos;
        }
        
        public Produto GetById(int id)
        {
            var produto = _repository.GetById(id);
            return produto;
        }

        public int Insert(Produto entity)
        {
            return _repository.Insert(entity);
        }

        public int Update(Produto entity)
        {
            return _repository.Update(entity);
        }
    }
}