using System.Net;
using BackEnd.Domain.Base.Dtos;
using BackEnd.Domain.Base.Entities;
using BackEnd.Domain.Base.Service;
using BackEnd.Infrastructure.Base.ApiResponse;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Infrastructure.Base.ApiController;

public class BaseController<TEntity, TKey, TGetOutputDto, TGetListOutputDto, TCreateInput,
    TUpdateInput> : ControllerBase
    where TEntity : Entity<TKey>, IEntity<TKey>
    where TCreateInput : class, ICreateDto<TEntity, TKey>
    where TUpdateInput : class, IUpdateDto<TEntity, TKey>
    where TGetOutputDto : class, IDetailDto<TEntity, TKey>, new()
    where TGetListOutputDto : class, IDetailDto<TEntity, TKey>, new()
    where TKey : struct
{
    IBaseService<TEntity, TKey, TGetOutputDto, TGetListOutputDto, TCreateInput, TUpdateInput> _entityService;

    public BaseController(
        IBaseService<TEntity, TKey, TGetOutputDto, TGetListOutputDto, TCreateInput, TUpdateInput> entityService)
    {
        _entityService = entityService;
    }

    [HttpGet("index")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public virtual async Task<ApiResponse<List<TGetListOutputDto>>> HandleIndexAction(CancellationToken cancellationToken)
    {
        try
        {
            var result = await _entityService.GetListAsync(cancellationToken);

            return ApiResponse<List<TGetListOutputDto>>.Ok(result);
        }
        catch (Exception e)
        {
            return ApiResponse<List<TGetListOutputDto>>.Error(e.Message);
        }
    }

    [HttpGet("show/{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public virtual async Task<ApiResponse<TGetOutputDto>> ShowAction(TKey id, CancellationToken cancellationToken)
    {
        try
        { 
            var result = await _entityService.GetAsync(id, cancellationToken);

            return ApiResponse<TGetOutputDto>.Ok(result);
        }
        catch (Exception e)
        {
            return ApiResponse<TGetOutputDto>.Error(e.Message);
        }
    }

    [HttpPost("create")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public virtual async Task<ApiResponse<TGetOutputDto>> HandleCreateAction([FromBody] TCreateInput request,
        CancellationToken cancellationToken)
    {
        try
        { 
            var result = await _entityService.CreateAsync(request, cancellationToken);

            return ApiResponse<TGetOutputDto>.Ok(result);
        }
        catch (Exception e)
        {
            return ApiResponse<TGetOutputDto>.Error(e.Message);
        }
    }

    [HttpPost("update/{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public virtual async Task<ApiResponse<TGetOutputDto>> HandleUpdateAction(TKey id, [FromBody] TUpdateInput request,
        CancellationToken cancellationToken)
    {
        try
        { 
            var result = await _entityService.UpdateAsync(id, request, cancellationToken);

            return ApiResponse<TGetOutputDto>.Ok(result);
        }
        catch (Exception e)
        {
            return ApiResponse<TGetOutputDto>.Error(e.Message);
        }
    }

    [HttpDelete("delete")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public virtual async Task<ApiResponse<string>> HandleDeleteAction(TKey id, CancellationToken cancellationToken)
    {
        try
        {         
            await _entityService.DeleteAsync(id, cancellationToken);
            return ApiResponse<string>.Ok("Record deleted successfully.");
        }
        catch (Exception e)
        {
            return ApiResponse<string>.Error(e.Message);
        }
    }
}