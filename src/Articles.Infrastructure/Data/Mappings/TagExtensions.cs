using Articles.Domain.Entities;
using Articles.Infrastructure.Data.Models;

namespace Articles.Infrastructure.Data.Mappings;

internal static class TagExtensions
{
    extension(TagDbModel model)
    {
        internal Tag ToEntity()
        {
            return new Tag
            {
                Id = model.Id,
                Name = model.Name
            };
        }
    }
}