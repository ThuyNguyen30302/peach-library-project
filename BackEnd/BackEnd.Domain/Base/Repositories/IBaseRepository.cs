using BackEnd.Domain.Base.Entities;
using BackEnd.Domain.Base.Spectification;

namespace BackEnd.Domain.Base.Repositories;

public interface IBaseRepository<TEntity, TPrimaryKey> where TEntity : Entity<TPrimaryKey>
{
    Task<TEntity> GetAsync(TPrimaryKey id, CancellationToken cancellationToken);
    Task<IEnumerable<TEntity>> GetListAsync(CancellationToken cancellationToken);

    Task<IEnumerable<TEntity>> GetListAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken);
    Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id, CancellationToken cancellationToken);
    Task<TEntity> FirstOrDefaultAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken);
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    Task DeleteAsync(TPrimaryKey id, CancellationToken cancellationToken);
    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);
    Task<int> CountAsync(CancellationToken cancellationToken);
    Task<int> CountAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken);
    Task<ICollection<TEntity>> AddRangeAsync (ICollection<TEntity> entities, CancellationToken cancellationToken);
}