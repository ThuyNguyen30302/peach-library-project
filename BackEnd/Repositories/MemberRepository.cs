using Abp.EntityFrameworkCore;
using BackEnd.Entities;

namespace BackEnd.Repositories;

public class MemberRepository : Repository<Member, Guid>, IMemberRepository
{
    public MemberRepository(IDbContextProvider<MigrationDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}