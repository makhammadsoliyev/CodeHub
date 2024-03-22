using CodeHub.Api.Models;
using CodeHub.Service.Exceptions;

namespace CodeHub.Api.Middlewares;

public class ExceptionHandlerMiddleWare(RequestDelegate next)
{
    private readonly RequestDelegate next = next;

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (CustomException ex)
        {
            context.Response.StatusCode = ex.StatusCode;
            await context.Response.WriteAsJsonAsync(new Response()
            {
                Message = ex.Message,
                StatusCode = ex.StatusCode
            });
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(new Response()
            {
                Message = ex.Message,
                StatusCode = 500
            });
        }
    }
}
