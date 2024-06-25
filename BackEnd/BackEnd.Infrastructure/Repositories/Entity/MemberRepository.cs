using BackEnd.Domain.Entity.Entities;
using BackEnd.Domain.Entity.Repositories;
using BackEnd.Infrastructure.Base.Repositories;
using BackEnd.Infrastructure.Data;

namespace BackEnd.Infrastructure.Repositories.Entity;

public class MemberRepository : BaseRepository<ApplicationDbContext, Member, Guid>, IMemberRepository
{
    public MemberRepository(ApplicationDbContext dbContext, IServiceProvider serviceProvider) : base(dbContext,
        serviceProvider)
    {
    }
}