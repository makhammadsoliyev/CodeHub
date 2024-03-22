using CodeHub.Domain.Commons;

namespace CodeHub.DataAccess.Repositories;

public interface IGenericRepository<TEntity> where TEntity : Auditable
{
    Task<TEntity> InsertAsync(TEntity entity);  
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<bool> DeleteAsync(TEntity entity);
    Task<TEntity> SelectByIdAsync(long id, string[] includes = null);
    IEnumerable<TEntity> SelectAsEnumerableAsync(string[] includes = null);
    IQueryable<TEntity> SelectAsQueryable(string[] includes = null);
    Task SaveAsync();
}
