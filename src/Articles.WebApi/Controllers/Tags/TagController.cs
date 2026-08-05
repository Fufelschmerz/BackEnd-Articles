using Articles.Application.Services.Interfaces;
using Articles.WebApi.Controllers.Tags.Mappings;
using Articles.WebApi.Controllers.Tags.Requests;
using Articles.WebApi.Controllers.Tags.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Articles.WebApi.Controllers.Tags;

/// <summary>
///     Контроллер для тэгов
/// </summary>
/// <param name="tagService"></param>
[ApiController]
[Route("api/v1/tag")]
public sealed class TagController(ITagService tagService) : ControllerBase
{
    /// <summary>
    ///     Создать тэг
    /// </summary>
    /// <param name="request">Тело запроса</param>
    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> CreateAsync(TagCreateRequest request)
    {
        var id = await tagService.CreateAsync(request.Name);

        return Ok(id);
    }

    /// <summary>
    ///     Получить список тэгов
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(TagGetListResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetListAsync([FromQuery] TagGetListRequest request)
    {
        var tags = await tagService.GetListAsync(request.Name,
            request.Count);

        var dtos = tags.Select(t => t.ToDto()).ToList();

        var response = new TagGetListResponse(dtos);

        return Ok(response);
    }
}