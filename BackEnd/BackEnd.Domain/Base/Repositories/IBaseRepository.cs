using BackEnd.Domain.Base.Entities;
using BackEnd.Domain.Base.Specification;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Domain.Base.Repositories;

public interface IBaseRepository<TEntity, TPrimaryKey> where TEntity : Entity<TPrimaryKey>
{
    public DbContext GetDbContext();
    IQueryable<TEntity> GetQueryable();
    Task<TEntity> GetAsync(TPrimaryKey id, CancellationToken cancellationToken);
    Task<IEnumerable<TEntity>> GetListAsync(CancellationToken cancellationToken);

    Task<IEnumerable<TEntity>> GetListAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken);
    Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id, CancellationToken cancellationToken);
    Task<TEntity> FirstOrDefaultAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken);
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken, bool save = true);
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    Task DeleteAsync(TPrimaryKey id, CancellationToken cancellationToken);
    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);
    Task<int> CountAsync(CancellationToken cancellationToken);
    Task<int> CountAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken);
    Task<ICollection<TEntity>> AddRangeAsync (ICollection<TEntity> entities, CancellationToken cancellationToken);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}