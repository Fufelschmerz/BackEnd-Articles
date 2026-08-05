using Articles.Domain.Entities;
using Articles.WebApi.Controllers.Articles.Mappings;
using Articles.WebApi.Controllers.CatalogArticles.Dto;
using Articles.WebApi.Controllers.Tags.Mappings;

namespace Articles.WebApi.Controllers.CatalogArticles.Mappings;

internal static class SectionModelExtensions
{
    extension(Section section)
    {
        internal SectionDto ToDto()
        {
            var articles = section.Articles.Select(a => a.ToListItemDto());

            var tags = section.Tags.Select(t => t.ToDto());

            var dto = new SectionDto(section.Id,
                section.Name,
                articles,
                tags);

            return dto;
        }

        internal SectionListItemDto ToListItemDto()
        {
            var dto = new SectionListItemDto(section.Id,
                section.Name,
                section.Articles.Count);

            return dto;
        }
    }
}