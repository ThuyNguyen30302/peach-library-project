using BackEnd.Domain.Base.Entities;
using BackEnd.Domain.Base.Repositories;
using BackEnd.Domain.Base.Specification;
using BackEnd.Infrastructure.Base.Spectification;
using BackEnd.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BackEnd.Infrastructure.Base.Repositories;

public class BaseRepository<TDbContext, TEntity, TPrimaryKey> : IBaseRepository<TEntity, TPrimaryKey>
    where TDbContext : DbContext
    where TEntity : Entity<TPrimaryKey>
{
    private readonly TDbContext _dbContext;
    protected readonly IServiceProvider ServiceProvider;
    
    public BaseRepository(TDbContext dbContext, IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
        _dbContext = serviceProvider.GetRequiredService<TDbContext>();
    }

    public DbContext GetDbContext()
    {
        return _dbContext;
    }

    public IQueryable<TEntity> GetQueryable()
    {
        return _dbContext.Set<TEntity>().AsQueryable();
    }

    public async Task<TEntity> GetAsync(TPrimaryKey id, CancellationToken cancellationToken)
    {
        return await _dbContext.Set<TEntity>().FindAsync(id, cancellationToken);
    }

    public async Task<IEnumerable<TEntity>> GetListAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Set<TEntity>().ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<TEntity>> GetListAsync(ISpecification<TEntity> specification,
        CancellationToken cancellationToken)
    {
        return await ApplySpecification(specification).ToListAsync(cancellationToken);
    }

    public async Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id, CancellationToken cancellationToken)
    {
        // var x = await _dbContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(cancellationToken: cancellationToken);
        // var y = GetPrimaryKeyValue(x);
        // throw new Exception();
        return await _dbContext.Set<TEntity>().FirstOrDefaultAsync(e => Equals(e.Id, id), cancellationToken);
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

    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken, bool save = true)
    {
        await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
        if (!save) return entity;;
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
        var entity = await _dbContext.Set<TEntity>().FindAsync(id, cancellationToken);
        if (entity != null)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
    {
        _dbContext.Set<TEntity>().Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public Task<int> CountAsync(CancellationToken cancellationToken)
    {
        return _dbContext.Set<TEntity>().CountAsync(cancellationToken);
    }

    public async Task<int> CountAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken)
    {
        
        return await ApplySpecification(specification).CountAsync(cancellationToken);
    }

    public async Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entities,
        CancellationToken cancellationToken)
    {
        await _dbContext.Set<TEntity>().AddRangeAsync(entities, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entities;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public IQueryable<TEntity> GetQueryableAsync(bool asNoTracking = false)
    {
        var query = _dbContext.Set<TEntity>().AsQueryable();

        if (asNoTracking)
        {
            query = query.AsNoTracking();
        }

        return query;
    }

    private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> specification)
    {
        return SpecificationEvaluator<TEntity>.GetQuery(_dbContext.Set<TEntity>().AsQueryable(), specification);
    }
}