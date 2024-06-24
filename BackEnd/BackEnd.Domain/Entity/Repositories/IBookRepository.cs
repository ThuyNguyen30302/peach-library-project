using BackEnd.Domain.Base.Repositories;
using BackEnd.Domain.Entities;

namespace BackEnd.Domain.Entity.Repositories;

public interface IBookRepository : IBaseRepository<Book, Guid>
{
    
}