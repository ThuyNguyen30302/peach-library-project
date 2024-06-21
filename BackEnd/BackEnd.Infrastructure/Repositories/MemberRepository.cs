using BackEnd.Domain.Entities;
using BackEnd.Domain.Repositories;
using BackEnd.Infrastructure.Base.Repositories;
using BackEnd.Infrastructure.Data;

namespace BackEnd.Infrastructure.Repositories;

public class MemberRepository : BaseRepository<ApplicationDbContext, Member, Guid>, IMemberRepository
{
    public MemberRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}