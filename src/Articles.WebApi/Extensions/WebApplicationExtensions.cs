using Articles.Infrastructure.Data;

namespace Articles.WebApi.Extensions;

internal static class WebApplicationExtensions
{
    public static void ApplyMigrations(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        dbContext.ApplyMigrations();
    }
}