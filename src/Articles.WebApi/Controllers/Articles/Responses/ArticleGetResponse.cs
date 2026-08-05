using Articles.WebApi.Controllers.Articles.Dto;

namespace Articles.WebApi.Controllers.Articles.Responses;

/// <summary>
///     Ответ на получение списка статей
/// </summary>
/// <param name="Article">Список статей</param>
public sealed record ArticleGetResponse(ArticleDto Article);