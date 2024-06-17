using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace BackEnd.Base.Dto;

public interface IDetailDto<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
    where TKey : struct
{
    public void FromEntity(TEntity entity);
}