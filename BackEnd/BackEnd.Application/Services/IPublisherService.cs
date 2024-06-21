using BackEnd.Application.Dtos;
using BackEnd.Domain.Base.Service;
using BackEnd.Domain.Entities;

namespace BackEnd.Application.Services;

public interface IPublisherService: IBaseService<Publisher, Guid, PublisherDetailDto,
    PublisherDetailDto,
    PublisherCreateDto,
    PublisherUpdateDto>
{ 
}