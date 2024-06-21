using BackEnd.Application.Dtos;
using BackEnd.Domain.Entities;
using BackEnd.Domain.Repositories;
using BackEnd.Infrastructure.Base.Service;

namespace BackEnd.Application.Services;

public class CataloService: BaseService<Catalo, Guid, CataloDetailDto,
    CataloDetailDto,
    CataloCreateDto,
    CataloUpdateDto>, ICataloService
{
    public CataloService(ICataloRepository entityRepository) : base(
        entityRepository)
    {
    }
}