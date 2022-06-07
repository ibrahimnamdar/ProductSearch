using System.Linq.Expressions;
using ProductSearch.Domain.Base;

namespace ProductSearch.Infrastructure.Repositories
{
    public interface IRepository<T> where T : class, IEntity
    {
        IQueryable<T> GetAll();
        Task<T> GetAsync(int id);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(ICollection<T> entities);
        bool Update(T entity);
        List<T> UpdateRange(List<T> entities);
        Task<bool> DeleteAsync(int id);
    }
}