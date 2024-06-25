using BackEnd.Application.Dtos;
using BackEnd.Application.Model;
using BackEnd.Domain.Base.Service;
using BackEnd.Domain.Entity.Entities;

namespace BackEnd.Application.Services;

public interface IAuthorService : IBaseService<Author, Guid, AuthorDetailDto,
    AuthorDetailDto,
    AuthorCreateDto,
    AuthorUpdateDto>
{ 
    Task<List<ComboOption<Guid, string>>> GetComboOptionAuthor(CancellationToken cancellationToken);
}