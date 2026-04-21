using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Contract.Repositories
{
    public interface IRepository<T> where T:class
    {
         Task<int> Insert(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
    }
}
