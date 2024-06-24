using System.Net;
using BackEnd.Application.Dtos;
using BackEnd.Application.Model;
using BackEnd.Application.Services;
using BackEnd.Domain.Entities;
using BackEnd.Infrastructure.Base.ApiController;
using BackEnd.Infrastructure.Base.ApiResponse;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.WebApi.Controllers;

// [Authorize]
[ApiController]
[Route("/api/catalo")]
public class CataloController : BaseController<Catalo, Guid, CataloDetailDto,
    CataloDetailDto,
    CataloCreateDto,
    CataloUpdateDto>
{
    private readonly ICataloService _cataloService;

    public CataloController(ICataloService entityService, ICataloService cataloService) : base(
        entityService)
    {
        _cataloService = cataloService;
    }

    [HttpGet("get-catalo-by-meta-catalo-id/{metaCataloId}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public virtual async Task<ApiResponse<List<CataloDetailDto>>> HandleGetCataloByMetaCataloIdAction(
        Guid metaCataloId, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _cataloService.GetListCataloByMetaCataloIdeAsync(metaCataloId, cancellationToken);

            return ApiResponse<List<CataloDetailDto>>.Ok(result);
        }
        catch (Exception e)
        {
            return ApiResponse<List<CataloDetailDto>>.Error(e.Message);
        }
    }
    
    [HttpGet("get-combo-option-code/{metaCataloCode}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public virtual async Task<ApiResponse<List<ComboOption<string, string>>>> HandleGetComboOptionCodeAction(
        string metaCataloCode, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _cataloService.GetComboOptionCodeCatalo(metaCataloCode, cancellationToken);

            return ApiResponse<List<ComboOption<string, string>>>.Ok(result);
        }
        catch (Exception e)
        {
            return ApiResponse<List<ComboOption<string, string>>>.Error(e.Message);
        }
    }
}