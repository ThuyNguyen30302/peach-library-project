using BackEnd.Domain.Entity.Entities;
using BackEnd.Domain.Entity.Repositories;
using BackEnd.Infrastructure.Base.Repositories;
using BackEnd.Infrastructure.Data;

namespace BackEnd.Infrastructure.Repositories.Entity;

public class PublisherRepository : BaseRepository<ApplicationDbContext, Publisher, Guid>, IPublisherRepository
{
    public PublisherRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}