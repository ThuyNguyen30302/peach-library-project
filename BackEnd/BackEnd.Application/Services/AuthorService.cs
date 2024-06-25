using BackEnd.Application.Dtos;
using BackEnd.Application.Model;
using BackEnd.Domain.Entity.Entities;
using BackEnd.Domain.Entity.Repositories;
using BackEnd.Infrastructure.Base.Service;

namespace BackEnd.Application.Services;

public class AuthorService : BaseService<Author, Guid, AuthorDetailDto,
    AuthorDetailDto,
    AuthorCreateDto,
    AuthorUpdateDto>, IAuthorService
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorService(IAuthorRepository entityRepository, IAuthorRepository authorRepository) : base(
        entityRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<List<ComboOption<Guid, string>>> GetComboOptionAuthor(CancellationToken cancellationToken)
    {
        var authorList = await _authorRepository.GetListAsync(cancellationToken);

        var comboOption = authorList.Select(x => new ComboOption<Guid, string>()
        {
            Value = x.Id,
            Label = x.Name
        }).ToList();

        return comboOption;
    }
}