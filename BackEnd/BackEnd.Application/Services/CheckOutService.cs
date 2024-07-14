using BackEnd.Application.Dtos;
using BackEnd.Domain.Entity.Entities;
using BackEnd.Domain.Entity.Repositories;
using BackEnd.Infrastructure.Base.Service;

namespace BackEnd.Application.Services;

public class CheckOutService: BaseService<CheckOut, Guid, CheckOutDetailDto,
    CheckOutDetailDto,
    CheckOutCreateDto,
    CheckOutUpdateDto>, ICheckOutService
{
    public CheckOutService(ICheckOutRepository entityRepository) : base(entityRepository)
    {
    }
}