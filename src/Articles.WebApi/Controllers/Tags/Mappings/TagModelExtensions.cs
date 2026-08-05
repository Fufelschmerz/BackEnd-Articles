using Articles.Domain.Entities;
using Articles.WebApi.Controllers.Tags.Dto;

namespace Articles.WebApi.Controllers.Tags.Mappings;

internal static class TagModelExtensions
{
    internal static TagDto ToDto(this Tag tag) =>
        new(tag.Id, tag.Name);
}