using System.Net;
using Abp.Domain.Entities;
using Abp.WebApi.Controllers;
using BackEnd.Base.Dto;
using BackEnd.Base.Model;
using BackEnd.Base.Service;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Base.ApiController;

public class BaseController<TEntity, TKey, TGetOutputDto, TGetListOutputDto, TCreateInput,
    TUpdateInput> : Controller
    where TEntity : class, IEntity<TKey>
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
    public virtual async Task<IActionResult> HandleIndexAction()
    {
        var result = await _entityService.GetListAsync();

        return Ok(result);
    }

    [HttpGet("show/{id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public virtual async Task<IActionResult> ShowAction(TKey id)
    {
        var result = await _entityService.GetAsync(id);
        return Ok(result);
    }

    [HttpPost("create")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public virtual async Task<IActionResult> HandleCreateAction([FromBody] TCreateInput request)
    {
        var result = await _entityService.CreateAsync(request);
        return Ok(result);
    }

    [HttpPost("update")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public virtual async Task<IActionResult> HandleUpdateAction([FromBody] TUpdateInput request)
    {
        var result = await _entityService.UpdateAsync(request.Id, request);
        return Ok(result);
    }
    
    [HttpDelete("delete")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public virtual async Task<IActionResult> HandleDeleteAction(TKey id)
    {
        await _entityService.DeleteAsync(id);
        return Ok();
    }
}