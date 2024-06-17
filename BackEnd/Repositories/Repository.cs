using Abp.Domain.Entities;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;

namespace BackEnd.Repositories;

public class Repository<TEntity, TPrimaryKey> : EfCoreRepositoryBase<MigrationDbContext, TEntity, TPrimaryKey>
    where TEntity : class, IEntity<TPrimaryKey>
{
    public Repository(IDbContextProvider<MigrationDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}

// public abstract class Repository<TEntity> : Repository<TEntity, Guid>
//     where TEntity : class, IEntity<Guid>
// {
//     protected Repository(IDbContextProvider<MigrationDbContext> dbContextProvider)
//         : base(dbContextProvider)
//     {
//
//     }
// }