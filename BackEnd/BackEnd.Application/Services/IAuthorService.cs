using BackEnd.Application.Dtos;
using BackEnd.Domain.Base.Service;
using BackEnd.Domain.Entities;

namespace BackEnd.Application.Services;

public interface IAuthorService : IBaseService<Author, Guid, AuthorDetailDto,
    AuthorDetailDto,
    AuthorCreateDto,
    AuthorUpdateDto>
{ 
}