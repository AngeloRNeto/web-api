using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.Services
{
    public interface IBaseService<T> where T : class
    {
        int Insert(T entity);
        int Update(T entity);
        void Delete(int id);
        T GetById(int id);
        List<T> GetAll<TEntity>();
    }
}
