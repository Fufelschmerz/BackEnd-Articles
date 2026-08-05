using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Articles.Infrastructure.Data;

public static class DbContextExtensions
{
    public static void ApplyMigrations(this DbContext dbContext)
    {
        var database = dbContext.Database;
        var definedMigrations = database.GetMigrations();
        var appliedMigrations = database.GetAppliedMigrations();
        var extraDatabaseMigrations = appliedMigrations.Except(definedMigrations).ToArray();
        if (extraDatabaseMigrations.Length != 0)
        {
            var errorMessageBuilder =
                new StringBuilder("В базе данных обнаружены установленные миграции, отсутствующие в коде:");
            errorMessageBuilder.Append(Environment.NewLine);
            errorMessageBuilder.AppendJoin(Environment.NewLine, extraDatabaseMigrations);
            errorMessageBuilder.Append(Environment.NewLine);
            errorMessageBuilder.Append("Убедитесь в том, что запускаете актуальную версию приложения");

            throw new InvalidOperationException(errorMessageBuilder.ToString());
        }

        database.Migrate();
    }
}