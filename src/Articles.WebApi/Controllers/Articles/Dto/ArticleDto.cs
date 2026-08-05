using Articles.WebApi.Controllers.Tags.Dto;

namespace Articles.WebApi.Controllers.Articles.Dto;

/// <summary>
///     Статья
/// </summary>
/// <param name="Id">Идентификатор</param>
/// <param name="Name">Название</param>
/// <param name="CreatedAt">Дата создания</param>
/// <param name="ModifyAt">Дата обновления</param>
/// <param name="Tags">Тэги</param>
public sealed record ArticleDto(Guid Id,
    string Name,
    DateTime CreatedAt,
    DateTime? ModifyAt,
    IEnumerable<TagDto> Tags);