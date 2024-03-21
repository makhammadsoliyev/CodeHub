using CodeHub.DataAccess.Contexts;
using CodeHub.Domain.Commons;
using Microsoft.EntityFrameworkCore;

namespace CodeHub.DataAccess.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    private readonly AppDbContext dbContext;
    private readonly DbSet<TEntity> dbSet;

    public Repository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
        this.dbSet = dbContext.Set<TEntity>();
    }

    public async Task<bool> DeleteAsync(TEntity entity)
    {
        await Task.FromResult(dbSet.Remove(entity).Entity);

        return true;
    }

    public async Task<TEntity> InsertAsync(TEntity entity)
    {
        var entry = await dbSet.AddAsync(entity);

        return entry.Entity;
    }

    public async Task SaveAsync()
    {
        await dbContext.SaveChangesAsync();
    }

    public IEnumerable<TEntity> SelectAsEnumerableAsync(string[] includes = null)
    {
        var query = dbSet;

        if (includes is not null)
            foreach (var include in includes)
                query.Include(include);

        return query;
    }

    public IQueryable<TEntity> SelectAsQueryableAsync(string[] includes = null)
    {
        var query = dbSet;

        if (includes is not null)
            foreach (var include in includes)
                query.Include(include);

        return query;
    }

    public async Task<TEntity> SelectByIdAsync(long id, string[] includes = null)
    {
        var query = dbSet.Where(e => e.Id == id);

        if (includes is not null)
            foreach (var include in includes)
                query.Include(include);
        var entity = await query.FirstOrDefaultAsync();

        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var entry = dbSet.Update(entity);

        return await Task.FromResult(entry.Entity);
    }
}
