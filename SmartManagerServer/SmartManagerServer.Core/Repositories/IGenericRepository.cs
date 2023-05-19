using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartManagerServer.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetBaseAsync(int id);
        Task<IEnumerable<T>> GetBaseAllAsync();
        Task<IEnumerable<T>> GetBaseAsync(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
