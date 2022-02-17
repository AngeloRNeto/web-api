using WebApi.Domain.Models;
using WebApi.Domain.Repositories;
using WebApi.Domain.Services;

namespace WebApi.Service
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _repository;
        public EnderecoService(IEnderecoRepository repository)
        {
            _repository = repository;
        }

        public void Delete(int id)
        {
            _repository.Delete(GetById(id));
        }

        public List<Endereco> GetAll<TEntity>()
        {
            var enderecos = _repository.GetAll<Endereco>();

            return enderecos;
        }

        public Endereco GetById(int id)
        {
            var endereco = _repository.GetById(id);

            return endereco;
        }

        public int Insert(Endereco entity)
        {
            return _repository.Insert(entity);
        }

        public int Update(Endereco entity)
        {
            return _repository.Update(entity);
        }
    }
}