using BackEnd.Application.Dtos;
using BackEnd.Application.Model;
using BackEnd.Domain.Entity.Entities;
using BackEnd.Domain.Entity.Repositories;
using BackEnd.Infrastructure.Base.Service;

namespace BackEnd.Application.Services;

public class PublisherService: BaseService<Publisher, Guid, PublisherDetailDto,
    PublisherDetailDto,
    PublisherCreateDto,
    PublisherUpdateDto>, IPublisherService
{
    public PublisherService(IPublisherRepository entityRepository) : base(
        entityRepository)
    {
    }

    public async Task<List<ComboOption<Guid, string>>> GetComboOptionPublisher(CancellationToken cancellationToken)
    {
        var publishers = await _entityRepository.GetListAsync(cancellationToken);

        var comboOption = publishers.Select(x => new ComboOption<Guid, string>()
        {
            Value = x.Id,
            Label = x.Name
        }).ToList();

        return comboOption;
    }
}