using BackEnd.Domain.Base.Dtos;
using BackEnd.Domain.Base.Entities;
using BackEnd.Domain.Base.Specification;

namespace BackEnd.Domain.Base.Service;

public interface IBaseService<TEntity, TKey, TGetOutputDto, TGetListOutputDto, TCreateInput,
    TUpdateInput>
    where TEntity : Entity<TKey>, IEntity<TKey>
    where TCreateInput : class, ICreateDto<TEntity, TKey>
    where TUpdateInput : class, IUpdateDto<TEntity, TKey>
    where TGetOutputDto : class, IDetailDto<TEntity, TKey>, new()
    where TGetListOutputDto : class, IDetailDto<TEntity, TKey>, new()
    where TKey : struct
{
    // Task<PaginatedList<TGetListOutputDto>> GetListAsync(
    //     PaginatedListQuery query,
    //     CancellationToken cancellationToken = default);
    Task<List<TGetListOutputDto>> GetListAsync(CancellationToken cancellationToken);

    Task<List<TGetListOutputDto>> GetListAsync(ISpecification<TEntity> specification,
        CancellationToken cancellationToken);

    // Task<PaginatedList<TGetListOutputDto>> GetListAsync(
    //     PaginatedListQuery query,
    //     ISpecification<TEntity>? specification = null,
    //     CancellationToken cancellationToken = default);

    Task<TGetOutputDto> CreateAsync(TCreateInput createInput, CancellationToken cancellationToken);
    Task<TGetOutputDto> GetAsync(TKey id, CancellationToken cancellationToken);

    Task<TGetOutputDto> UpdateAsync(TKey id, TUpdateInput updateInput, CancellationToken cancellationToken);
    Task DeleteAsync(TKey id, CancellationToken cancellationToken);
}