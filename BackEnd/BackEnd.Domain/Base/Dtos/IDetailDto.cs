using BackEnd.Domain.Base.Entities;

namespace BackEnd.Domain.Base.Dtos;

public interface IDetailDto<TEntity, TKey>
    where TEntity : Entity<TKey>, IEntity<TKey>
    where TKey : struct
{
    public void FromEntity(TEntity entity);
}