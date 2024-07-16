using BackEnd.Application.Dtos;
using BackEnd.Domain.Base.Service;
using BackEnd.Domain.Entity.Entities;

namespace BackEnd.Application.Services;

public interface ICheckOutService: IBaseService<CheckOut, Guid, CheckOutDetailDto,
    CheckOutDetailDto,
    CheckOutCreateDto,
    CheckOutUpdateDto>
{ 
}