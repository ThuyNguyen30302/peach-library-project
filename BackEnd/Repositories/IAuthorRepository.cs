using Abp.Domain.Repositories;
using BackEnd.Entities;

namespace BackEnd.Repositories;

public interface IAuthorRepository : IRepository<Author, Guid>
{
    
}