using Articles.Application.Common.Exceptions;
using Articles.Domain.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Articles.WebApi.Middlewares;

internal sealed class ExceptionHandlingMiddleware(RequestDelegate next,
    ILogger<ExceptionHandlingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext httpContext,
        Exception exception)
    {
        httpContext.Response.ContentType = "application/json";

        switch (exception)
        {
            case ValidationException or EntityDuplicateException:
            {
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                var problemDetails = new ProblemDetails
                {
                    Type = "https://datatracker.ietf.org/doc/html/rfc9110#section-15.5.1",
                    Status = httpContext.Response.StatusCode,
                    Detail = exception.Message
                };
                await httpContext.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
                break;
            }

            case EntityNotFoundException notFoundException:
            {
                httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                var problemDetails = new ProblemDetails
                {
                    Type = "https://datatracker.ietf.org/doc/html/rfc9110#section-15.5.5",
                    Status = httpContext.Response.StatusCode,
                    Detail = notFoundException.Message
                };
                await httpContext.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
                break;
            }

            case ConcurrencyException concurrencyException:
            {
                httpContext.Response.StatusCode = StatusCodes.Status409Conflict;
                var problemDetails = new ProblemDetails
                {
                    Type = "https://datatracker.ietf.org/doc/html/rfc9110#section-15.5.10",
                    Status = httpContext.Response.StatusCode,
                    Detail = concurrencyException.Message
                };
                await httpContext.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
                break;
            }

            default:
                logger.LogError(exception, "{Exception}", exception);
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await httpContext.Response.WriteAsync(JsonSerializer.Serialize(new ProblemDetails
                {
                    Type = "https://datatracker.ietf.org/doc/html/rfc9110#section-15.6.1",
                    Status = httpContext.Response.StatusCode
                }));
                break;
        }
    }
}