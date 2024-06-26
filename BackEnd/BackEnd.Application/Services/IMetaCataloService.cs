using BackEnd.Application.Dtos;
using BackEnd.Domain.Base.Service;
using BackEnd.Domain.Entity.Entities;

namespace BackEnd.Application.Services;

public interface IMetaCataloService: IBaseService<MetaCatalo, Guid, MetaCataloDetailDto,
    MetaCataloDetailDto,
    MetaCataloCreateDto,
    MetaCataloUpdateDto>
{ 
}