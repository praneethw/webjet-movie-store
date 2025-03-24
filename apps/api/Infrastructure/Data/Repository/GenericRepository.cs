using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MovieStore.Api.Application.Common.Interfaces;
using MovieStore.Api.Domain.Common;

namespace MovieStore.Api.Infrastructure.Data.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseAuditableEntity
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
        _dbSet = _applicationDbContext.Set<T>();
    }

    public async Task<List<T>> GetAllAsync(params string[] includeProperties)
    {
        return await _dbSet.Include(string.Join(",", includeProperties)).ToListAsync();
    }

    public async Task<T?> GetByIdAsync(Guid id, params string[] includeProperties)
    {
        return await _dbSet.Include(string.Join(",", includeProperties)).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<T?> FindOneOrDefaultAsync(Expression<Func<T, bool>> predicate, params string[] includeProperties)
    {
        return await _dbSet.Include(string.Join(",", includeProperties)).Where(predicate).FirstOrDefaultAsync();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await SaveAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await SaveAsync();
    }

    public async Task SaveAsync()
    {
        await _applicationDbContext.SaveChangesAsync();
    }
}