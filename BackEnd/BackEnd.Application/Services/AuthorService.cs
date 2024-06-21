using BackEnd.Application.Dtos;
using BackEnd.Domain.Entities;
using BackEnd.Domain.Repositories;
using BackEnd.Infrastructure.Base.Service;

namespace BackEnd.Application.Services;

public class AuthorService: BaseService<Author, Guid, AuthorDetailDto,
    AuthorDetailDto,
    AuthorCreateDto,
    AuthorUpdateDto>, IAuthorService
{
    public AuthorService(IAuthorRepository entityRepository) : base(
        entityRepository)
    {
    }
}