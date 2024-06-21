using BackEnd.Application.Dtos;
using BackEnd.Domain.Base.Service;
using BackEnd.Domain.Entities;

namespace BackEnd.Application.Services;

public interface ICataloService: IBaseService<Catalo, Guid, CataloDetailDto,
    CataloDetailDto,
    CataloCreateDto,
    CataloUpdateDto>
{ 
}