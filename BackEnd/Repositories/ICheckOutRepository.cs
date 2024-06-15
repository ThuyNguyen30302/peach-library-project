using Abp.Domain.Repositories;
using BackEnd.Entities;

namespace BackEnd.Repositories;

public interface ICheckOutRepository : IRepository<CheckOut, Guid>
{
    
}