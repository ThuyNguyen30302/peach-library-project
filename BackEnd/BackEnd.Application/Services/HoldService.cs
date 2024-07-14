using BackEnd.Application.Dtos;
using BackEnd.Domain.Entity.Entities;
using BackEnd.Domain.Entity.Repositories;
using BackEnd.Infrastructure.Base.Service;

namespace BackEnd.Application.Services;

public class HoldService: BaseService<Hold, Guid, HoldDetailDto,
    HoldDetailDto,
    HoldCreateDto,
    HoldUpdateDto>, IHoldService
{
    public HoldService(IHoldRepository entityRepository) : base(entityRepository)
    {
    }
}