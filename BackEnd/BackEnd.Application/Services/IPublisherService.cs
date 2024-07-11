using BackEnd.Application.Dtos;
using BackEnd.Application.Model;
using BackEnd.Domain.Base.Service;
using BackEnd.Domain.Entity.Entities;

namespace BackEnd.Application.Services;

public interface IPublisherService: IBaseService<Publisher, Guid, PublisherDetailDto,
    PublisherDetailDto,
    PublisherCreateDto,
    PublisherUpdateDto>
{ 
    Task<List<ComboOption<Guid, string>>> GetComboOptionPublisher(CancellationToken cancellationToken);
}