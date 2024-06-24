using BackEnd.Domain.Entities;
using BackEnd.Domain.Entity.Repositories;
using BackEnd.Infrastructure.Base.Repositories;
using BackEnd.Infrastructure.Data;

namespace BackEnd.Infrastructure.Repositories.Entity;

public class MetaCataloRepository : BaseRepository<ApplicationDbContext, MetaCatalo, Guid>, IMetaCataloRepository
{
    public MetaCataloRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}