using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProductSearch.Domain.Base;

namespace ProductSearch.Infrastructure.Repositories;

public class EfCoreRepository<TEntity> : IRepository<TEntity>
    where TEntity : class, IEntity
{
    private readonly ProductSearchDbContext _context;

    public EfCoreRepository(ProductSearchDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        return true;
    }

    public async Task<bool> AddRangeAsync(ICollection<TEntity> entities)
    {
        await _context.Set<TEntity>().AddRangeAsync(entities);
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Set<TEntity>().FindAsync(id);
        if (entity == null)
        {
            return false;
        }

        _context.Set<TEntity>().Remove(entity);

        return true;
    }

    public async Task<TEntity> GetAsync(int id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
    }

    public IQueryable<TEntity> GetAll()
    {
        return _context.Set<TEntity>();
    }

    public bool Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        return true;
    }

    public List<TEntity> UpdateRange(List<TEntity> entities)
    {
        _context.Set<TEntity>().UpdateRange(entities);
        return entities;
    }
}