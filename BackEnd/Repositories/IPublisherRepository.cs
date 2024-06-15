using Abp.Domain.Repositories;
using BackEnd.Entities;

namespace BackEnd.Repositories;

public interface IPublisherRepository : IRepository<Publisher, Guid>
{
    
}