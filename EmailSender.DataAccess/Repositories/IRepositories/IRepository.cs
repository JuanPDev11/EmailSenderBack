using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.DataAccess.Repositories.IRepositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? predicate = null,string? includeProperties = null);
        Task<T> GetT(Expression<Func<T,bool>> predicate,string? includeProperties = null);
        Task Add(T entity);
        Task Delete(T entity);
        Task DeleteRange(IEnumerable<T> entities);
    }
}
