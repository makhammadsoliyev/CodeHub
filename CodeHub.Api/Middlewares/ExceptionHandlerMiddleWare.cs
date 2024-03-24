using CodeHub.Api.Models;
using CodeHub.Service.Exceptions;

namespace CodeHub.Api.Middlewares;

public class ExceptionHandlerMiddleWare
{
    private readonly RequestDelegate next;

    public ExceptionHandlerMiddleWare(RequestDelegate next)
    {
        this.next = next;
    }

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
