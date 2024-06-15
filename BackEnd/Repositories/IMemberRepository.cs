using Abp.Domain.Repositories;
using BackEnd.Entities;

namespace BackEnd.Repositories;

public interface IMemberRepository : IRepository<Member, Guid>
{
    
}