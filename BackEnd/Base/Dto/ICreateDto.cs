using Abp.Domain.Entities;

namespace BackEnd.Base.Dto;

public interface ICreateDto<TEntity, TKey> where TEntity : class, IEntity<TKey>
    where TKey : struct
{
    public TEntity GetEntity();
}