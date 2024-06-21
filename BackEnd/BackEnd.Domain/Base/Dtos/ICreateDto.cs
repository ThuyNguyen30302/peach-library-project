using BackEnd.Domain.Base.Entities;

namespace BackEnd.Domain.Base.Dtos;

public interface ICreateDto<TEntity, TKey> where TEntity : Entity<TKey>, IEntity<TKey>
    where TKey : struct
{
    public TEntity GetEntity();
}