using BackEnd.Domain.Base.Entities;

namespace BackEnd.Domain.Base.Dtos;

public interface IUpdateDto<TEntity, TKey>
    where TEntity : Entity<TKey>, IEntity<TKey>
    where TKey : struct
{
    public TKey Id { get; set; }
    public TEntity GetEntity(TEntity entity);
}