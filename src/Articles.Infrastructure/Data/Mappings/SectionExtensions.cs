using Articles.Domain.Entities;
using Articles.Infrastructure.Data.Models;

namespace Articles.Infrastructure.Data.Mappings;

internal static class SectionExtensions
{
    extension(SectionDbModel model)
    {
        internal Section ToEntity()
        {
            var tags = model.Tags.Select(t => t.ToEntity()).ToArray();
            var articles = model.Articles.Select(m => m.ToListItemEntity()).ToArray();
            var section = new Section(tags)
            {
                Id = model.Id,
                Articles = articles,
            };
            return section;
        }
    }
}