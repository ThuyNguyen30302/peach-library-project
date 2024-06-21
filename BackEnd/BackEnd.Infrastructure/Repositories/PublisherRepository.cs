using BackEnd.Domain.Entities;
using BackEnd.Domain.Repositories;
using BackEnd.Infrastructure.Base.Repositories;
using BackEnd.Infrastructure.Data;

namespace BackEnd.Infrastructure.Repositories;

public class PublisherRepository : BaseRepository<ApplicationDbContext, Publisher, Guid>, IPublisherRepository
{
    public PublisherRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}