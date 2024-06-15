using Abp.Domain.Repositories;
using BackEnd.Entities;

namespace BackEnd.Repositories;

public interface IBookRepository : IRepository<Book, Guid>
{
    
}