using System.Linq.Expressions;

namespace MovieStore.Api.Application.Common.Interfaces;

public interface IGenericRepository<T>
{
    Task<List<T>> GetAllAsync(params string[] includeProperties);
    Task<T?> GetByIdAsync(Guid id, params string[] includeProperties);
    Task<T?> FindOneOrDefaultAsync(Expression<Func<T, bool>> predicate, params string[] includeProperties);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task SaveAsync();
}