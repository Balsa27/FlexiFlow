using System.Net;
using FlexiFlow.Exception;

namespace FlexiFlow.Infrastructure.Jwt;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (System.Exception ex)
        {
            if (context.Response.HasStarted)
                throw;

            var response = context.Response;
            response.ContentType = "application/json";

            response.StatusCode = ex switch
            {
                AggregateException or KeyNotFoundException or TokenNotFoundException or UserNotFoundException =>
                    (int) HttpStatusCode.NotFound,

                FormatException or ArgumentNullException or DuplicateEmailException or InvalidCredentialsException =>
                    (int) HttpStatusCode.BadRequest,

                _ => (int) HttpStatusCode.InternalServerError,
            };

            var result = ex.Message;
            await response.WriteAsync(result);
        }
    }
}