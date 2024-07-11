using System.Net;
using BackEnd.Application.Dtos;
using BackEnd.Application.Model;
using BackEnd.Application.Services;
using BackEnd.Domain.Entity.Entities;
using BackEnd.Infrastructure.Base.ApiController;
using BackEnd.Infrastructure.Base.ApiResponse;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.WebApi.Controllers;

[ApiController]
[Route("/api/book-copy")]
public class BookCopyController : BaseController<BookCopy, Guid, BookCopyDetailDto,
    BookCopyDetailDto,
    BookCopyCreateDto,
    BookCopyUpdateDto>
{
    private readonly IBookCopyService _bookCopyService;

    public BookCopyController(IBookCopyService entityService, IBookCopyService bookCopyService) : base(entityService)
    {
        _bookCopyService = bookCopyService;
    }

    [HttpGet("get-book-copies-tree")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public virtual async Task<ApiResponse<List<BookCopyDetailTreeDto>>> HandleIndexTreeAction(
        CancellationToken cancellationToken)
    {
        try
        {
            var result = await _bookCopyService.GetBookCopyTreeAsync(cancellationToken);

            return ApiResponse<List<BookCopyDetailTreeDto>>.Ok(result);
        }
        catch (Exception e)
        {
            return ApiResponse<List<BookCopyDetailTreeDto>>.Error(e.Message);
        }
    }

    [HttpGet("get-book-copies")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public virtual async Task<ApiResponse<List<BookCopyDetailByAmountDto>>> HandleIndexGridAction(
        [FromQuery] DateTime startDate, [FromQuery] DateTime endDate, CancellationToken cancellationToken)
    {
        try
        {
            var filter = new FilterDateRange()
            {
                StartDate = startDate,
                EndDate = endDate
            };
            var result = await _bookCopyService.GetBookCopyGridAsync(filter, cancellationToken);

            return ApiResponse<List<BookCopyDetailByAmountDto>>.Ok(result);
        }
        catch (Exception e)
        {
            return ApiResponse<List<BookCopyDetailByAmountDto>>.Error(e.Message);
        }
    }

    [HttpPost("create-book-copies")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public virtual async Task<ApiResponse<List<BookCopyDetailDto>>> HandleCreateAction(
        [FromBody] List<BookCopyCreateByAmountDto> request,
        CancellationToken cancellationToken)
    {
        try
        {
            var result = await _bookCopyService.CreateBookCopyByAmountAsync(request, cancellationToken);

            return ApiResponse<List<BookCopyDetailDto>>.Ok(result);
        }
        catch (Exception e)
        {
            return ApiResponse<List<BookCopyDetailDto>>.Error(e.Message);
        }
    }
}