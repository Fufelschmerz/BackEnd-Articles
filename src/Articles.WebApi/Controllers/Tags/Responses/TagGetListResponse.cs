using Articles.WebApi.Controllers.Tags.Dto;

namespace Articles.WebApi.Controllers.Tags.Responses;

/// <summary>
///     Список найденных тэгов
/// </summary>
/// <param name="Tags">Список тэгов</param>
public sealed record TagGetListResponse(IEnumerable<TagDto> Tags);