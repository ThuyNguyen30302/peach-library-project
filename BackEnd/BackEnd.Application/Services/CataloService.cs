using BackEnd.Application.Dtos;
using BackEnd.Application.Model;
using BackEnd.Domain.Base.Specification;
using BackEnd.Domain.Entity.Entities;
using BackEnd.Domain.Entity.Repositories;
using BackEnd.Infrastructure.Base.Service;

namespace BackEnd.Application.Services;

public class CataloService : BaseService<Catalo, Guid, CataloDetailDto,
    CataloDetailDto,
    CataloCreateDto,
    CataloUpdateDto>, ICataloService
{
    private readonly IMetaCataloRepository _metaCataloRepository;
    private readonly ICataloRepository _cataloRepository;

    public CataloService(ICataloRepository entityRepository, IMetaCataloRepository metaCataloRepository,
        ICataloRepository cataloRepository) : base(
        entityRepository)
    {
        _metaCataloRepository = metaCataloRepository;
        _cataloRepository = cataloRepository;
    }

    public override async Task<CataloDetailDto> CreateAsync(CataloCreateDto createInput,
        CancellationToken cancellationToken)
    {
        var metaCatalo = await _metaCataloRepository.FirstOrDefaultAsync(createInput.MetaCataloId, cancellationToken);
        createInput.MetaCataloCode = metaCatalo?.Code;

        var newEntity = createInput.GetEntity();

        await _entityRepository.AddAsync(newEntity, cancellationToken);

        var res = new CataloDetailDto();

        res.FromEntity(newEntity);

        return res;
    }

    public async Task<List<ComboOption<string, string>>> GetComboOptionCodeCatalo(string metaCataloCode,
        CancellationToken cancellationToken)
    {
        var spec = new Specification<Catalo>(x => x.MetaCataloCode == metaCataloCode);

        var cataloList = await _cataloRepository.GetListAsync(spec, cancellationToken);

        var comboOption = cataloList.Select(x => new ComboOption<string, string>()
        {
            Value = x.Code,
            Label = x.Name
        }).ToList();

        return comboOption;
    }

    public async Task<List<CataloDetailDto>> GetListCataloByMetaCataloIdeAsync(Guid metaCataloId, CancellationToken cancellationToken)
    {
        var spec = new Specification<Catalo>(x => x.MetaCataloId == metaCataloId);

        var cataloList = await _cataloRepository.GetListAsync(spec, cancellationToken);

        return cataloList.Select(x =>
        {
            var res = new CataloDetailDto();

            res.FromEntity(x);

            return res;
        }).ToList();
    }
}