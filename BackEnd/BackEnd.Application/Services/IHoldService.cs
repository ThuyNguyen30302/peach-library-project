using BackEnd.Application.Dtos;
using BackEnd.Domain.Base.Service;
using BackEnd.Domain.Entity.Entities;

namespace BackEnd.Application.Services;

public interface IHoldService: IBaseService<Hold, Guid, HoldDetailDto,
    HoldDetailDto,
    HoldCreateDto,
    HoldUpdateDto>
{ 
}