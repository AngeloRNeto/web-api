using WebApi.Domain.Models;
using WebApi.Domain.Repositories;
using WebApi.Domain.Services;

namespace WebApi.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public void Delete(int id)
        {
            _repository.Delete(GetById(id));
        }

        public List<Usuario> GetAll<TEntity>()
        {
            var users = _repository.GetAll<Usuario>();
            return users;
        }

        public Usuario GetById(int id)
        {
            var usuario = _repository.GetById(id);
            return usuario;
        }

        public int Insert(Usuario entity)
        {
            return _repository.Insert(entity);
        }

        public int Update(Usuario entity)
        {
            return _repository.Update(entity);
        }
    }
}