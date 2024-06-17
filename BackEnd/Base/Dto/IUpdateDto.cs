using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace BackEnd.Base.Dto;

public interface IUpdateDto<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
    where TKey : struct
{
    public TKey Id { get; set; }
    public TEntity GetEntity(TEntity entity);
}