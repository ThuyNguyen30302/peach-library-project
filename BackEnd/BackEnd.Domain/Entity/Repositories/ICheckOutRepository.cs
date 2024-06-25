using BackEnd.Domain.Base.Repositories;
using BackEnd.Domain.Entity.Entities;

namespace BackEnd.Domain.Entity.Repositories;

public interface ICheckOutRepository : IBaseRepository<CheckOut, Guid>
{
    
}