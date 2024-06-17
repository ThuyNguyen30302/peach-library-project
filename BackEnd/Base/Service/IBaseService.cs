using System.Linq.Expressions;
using Abp.Domain.Entities;
using Abp.Specifications;
using BackEnd.Base.Dto;

namespace BackEnd.Base.Service;

public interface IBaseService<TEntity, TKey, TGetOutputDto, TGetListOutputDto, TCreateInput,
    TUpdateInput>
    where TEntity : class, IEntity<TKey>
    where TCreateInput : class, ICreateDto<TEntity, TKey>
    where TUpdateInput : class, IUpdateDto<TEntity, TKey>
    where TGetOutputDto : class, IDetailDto<TEntity, TKey>, new()
    where TGetListOutputDto : class, IDetailDto<TEntity, TKey>, new()
    where TKey : struct
{
    // Task<PaginatedList<TGetListOutputDto>> GetListAsync(
    //     PaginatedListQuery query,
    //     CancellationToken cancellationToken = default);
    Task<List<TGetListOutputDto>> GetListAsync();

    Task<List<TGetListOutputDto>> GetListAsync(Expression<Func<TEntity, bool>> predicate);

    // Task<PaginatedList<TGetListOutputDto>> GetListAsync(
    //     PaginatedListQuery query,
    //     ISpecification<TEntity>? specification = null,
    //     CancellationToken cancellationToken = default);

    Task<TGetOutputDto> CreateAsync(TCreateInput createInput);
    Task<TGetOutputDto> GetAsync(TKey id);

    Task<TGetOutputDto> UpdateAsync(TKey id, TUpdateInput updateInput);
    Task DeleteAsync(TKey id);
}