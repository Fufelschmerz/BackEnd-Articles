using Articles.Application.Services.Interfaces;
using Articles.WebApi.Controllers.Articles.Mappings;
using Articles.WebApi.Controllers.Articles.Requests;
using Articles.WebApi.Controllers.Articles.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Articles.WebApi.Controllers.Articles;

/// <summary>
///     Контроллер для статей
/// </summary>
[ApiController]
[Route("api/v1/article")]
public sealed class ArticleController(IArticleService articleService) : ControllerBase
{
    /// <summary>
    ///     Создать статью
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateAsync(ArticleCreateRequest request)
    {
        var id = await articleService.CreateAsync(request.Name,
            request.TagIds);

        return Ok(id);
    }

    /// <summary>
    ///     Удалить статью
    /// </summary>
    [HttpDelete]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var removedRows = await articleService.DeleteAsync(id);

        return Ok(removedRows);
    }

    /// <summary>
    ///     Обновить статью
    /// </summary>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateAsync(ArticleUpdateRequest request)
    {
        await articleService.UpdateAsync(request.Id, request.Name, request.TagIds);

        return Ok();
    }

    /// <summary>
    ///     Метод получения статьи по Id
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ArticleGetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
    {
        var article = await articleService.GetByIdAsync(id);

        var dto = article.ToDto();

        var response = new ArticleGetResponse(dto);

        return Ok(response);
    }
}