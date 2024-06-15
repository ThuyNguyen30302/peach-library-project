using Abp.Domain.Repositories;
using BackEnd.Entities;

namespace BackEnd.Repositories;

public interface IBookCopyRepository : IRepository<BookCopy, Guid>
{
    
}