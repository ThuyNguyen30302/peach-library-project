using Abp.Domain.Repositories;
using BackEnd.Entities;

namespace BackEnd.Repositories;

public interface IHoldRepository : IRepository<Hold, Guid>
{
    
}