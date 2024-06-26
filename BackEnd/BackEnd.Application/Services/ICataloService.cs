using BackEnd.Application.Dtos;
using BackEnd.Application.Model;
using BackEnd.Domain.Base.Service;
using BackEnd.Domain.Entity.Entities;

namespace BackEnd.Application.Services;

public interface ICataloService : IBaseService<Catalo, Guid, CataloDetailDto,
    CataloDetailDto,
    CataloCreateDto,
    CataloUpdateDto>
{
    Task<List<ComboOption<string, string>>> GetComboOptionCodeCatalo(string metaCataloCode,
        CancellationToken cancellationToken);

    Task<List<CataloDetailDto>> GetListCataloByMetaCataloIdeAsync(Guid metaCataloId, CancellationToken cancellationToken);
}