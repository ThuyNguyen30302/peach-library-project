using BackEnd.Application.Dtos;
using BackEnd.Domain.Entities;
using BackEnd.Domain.Repositories;
using BackEnd.Infrastructure.Base.Service;

namespace BackEnd.Application.Services;

public class MetaCataloService: BaseService<MetaCatalo, Guid, MetaCataloDetailDto,
    MetaCataloDetailDto,
    MetaCataloCreateDto,
    MetaCataloUpdateDto>, IMetaCataloService
{
    public MetaCataloService(IMetaCataloRepository entityRepository) : base(
        entityRepository)
    {
    }
}