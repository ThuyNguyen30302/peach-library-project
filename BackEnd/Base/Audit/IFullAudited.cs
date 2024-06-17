using Abp.Domain.Entities;

namespace BackEnd.Base.Audit;

public interface IFullAudited<TKey>: IEntity<TKey>, ICreationAudited, IModificationAudited, IDeletionAudited
{
    
}