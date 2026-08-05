using Articles.WebApi.Extensions;
using Articles.WebApi.Middlewares;
using Articles.WebApi.Swagger;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.ApplyMigrations();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void ConfigureServices(IServiceCollection services,
    IConfiguration configuration)
{
    services.AddControllers()
        .AddJsonOptions(opt => opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

    services.AddSwagger();

    Articles.Application.Module.ConfigureServices(services, configuration);
    Articles.Infrastructure.Module.ConfigureServices(services, configuration);
}