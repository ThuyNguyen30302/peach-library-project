using BackEnd.Domain.Base.Entities;
using BackEnd.Domain.Base.Repositories;
using BackEnd.Domain.Base.Spectification;
using BackEnd.Infrastructure.Base.Spectification;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Infrastructure.Base.Repositories;

public class BaseRepository<TDbContext, TEntity, TPrimaryKey> : IBaseRepository<TEntity, TPrimaryKey>
    where TDbContext : DbContext
    where TEntity : Entity<TPrimaryKey>
{
    private readonly TDbContext _dbContext;
    private readonly DbSet<TEntity> _dbSet;

    public BaseRepository(TDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<TEntity>();
    }

    public async Task<TEntity> GetAsync(TPrimaryKey id, CancellationToken cancellationToken)
    {
        return await _dbSet.FindAsync(id, cancellationToken);
    }

    public async Task<IEnumerable<TEntity>> GetListAsync(CancellationToken cancellationToken)
    {
        return await _dbSet.ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<TEntity>> GetListAsync(ISpecification<TEntity> specification,
        CancellationToken cancellationToken)
    {
        return await ApplySpecification(specification).ToListAsync(cancellationToken);
    }

    public async Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id, CancellationToken cancellationToken)
    {
        // var x = await _dbSet.AsNoTracking().FirstOrDefaultAsync(cancellationToken: cancellationToken);
        // var y = GetPrimaryKeyValue(x);
        // throw new Exception();
        return await _dbSet.FirstOrDefaultAsync(e => Equals(e.Id, id), cancellationToken);
    }

    private TPrimaryKey GetPrimaryKeyValue(TEntity entity)
    {
        var propertyInfo = entity.GetType().GetProperty("Id");
        if (propertyInfo == null)
        {
            throw new InvalidOperationException($"Entity type {typeof(TEntity).Name} does not have a property named 'Id'");
        }
        return (TPrimaryKey)propertyInfo.GetValue(entity);
    }

    public async Task<TEntity> FirstOrDefaultAsync(ISpecification<TEntity> specification,
        CancellationToken cancellationToken)
    {
        return await ApplySpecification(specification).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task DeleteAsync(TPrimaryKey id, CancellationToken cancellationToken)
    {
        var entity = await _dbSet.FindAsync(id, cancellationToken);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
    {
        _dbSet.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public Task<int> CountAsync(CancellationToken cancellationToken)
    {
        return _dbSet.CountAsync(cancellationToken);
    }

    public async Task<int> CountAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken)
    {
        return await ApplySpecification(specification).CountAsync(cancellationToken);
    }

    public async Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entities,
        CancellationToken cancellationToken)
    {
        await _dbSet.AddRangeAsync(entities, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entities;
    }

    public IQueryable<TEntity> GetQueryableAsync(bool asNoTracking = false)
    {
        var query = _dbSet.AsQueryable();

        if (asNoTracking)
        {
            query = query.AsNoTracking();
        }

        return query;
    }

    private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> specification)
    {
        return SpecificationEvaluator<TEntity>.GetQuery(_dbSet.AsQueryable(), specification);
    }
}