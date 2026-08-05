using Articles.WebApi.Swagger.Filters;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Articles.WebApi.Swagger;

internal static class SwaggerExtensions
{
    internal static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(opt =>
        {
            opt.SchemaFilter<RequiredPropertiesSchemaFilter>();
            opt.SupportNonNullableReferenceTypes();
            opt.UseAllOfToExtendReferenceSchemas();
            opt.UseAllOfForInheritance();
            opt.UseInlineDefinitionsForEnums();

            opt.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Backend-Articles API",
                    Description = "ASP.NET Core 8.0 Web Api"
                });

            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            opt.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });

        return services;
    }
}