using Articles.Application.Services.Interfaces;
using Articles.WebApi.Controllers.CatalogArticles.Mappings;
using Articles.WebApi.Controllers.CatalogArticles.Requests;
using Articles.WebApi.Controllers.CatalogArticles.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Articles.WebApi.Controllers.CatalogArticles;

/// <summary>
///     Каталог статей
/// </summary>
[ApiController]
[Route("api/v1/article/catalog")]
public sealed class CatalogArticlesController(ISectionService sectionService) : ControllerBase
{
    /// <summary>
    ///     Получить раздел по списку тэгов
    /// </summary>
    [HttpPost("section")]
    [ProducesResponseType(typeof(SectionGetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetByTagsAsync(SectionGetRequest request,
        CancellationToken cancellationToken = default)
    {
        var section = await sectionService.GetOrDefaultByTagsAsync(request.TagIds,
            cancellationToken);

        if (section == null)
        {
            return NoContent();
        }

        var dto = section.ToDto();

        var response = new SectionGetResponse(dto);

        return Ok(response);
    }

    /// <summary>
    ///     Получить разделы
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(SectionGetListResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetListAsync([FromQuery] SectionGetListRequest request,
        CancellationToken cancellationToken = default)
    {
        var queryResult = await sectionService.GetListAsync(request.PageSize,
            request.PageNumber,
            cancellationToken);

        var dtos = queryResult.Items.Select(s => s.ToListItemDto());

        var response = new SectionGetListResponse(queryResult.Number,
            queryResult.Size,
            queryResult.Total,
            dtos);

        return Ok(response);
    }
}