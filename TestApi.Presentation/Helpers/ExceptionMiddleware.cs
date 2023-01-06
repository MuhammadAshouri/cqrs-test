using TestApi.Application.Interfaces;
using TestApi.Domain.Exceptions;

namespace TestApi.Presentation.Helpers;

public class ExceptionMiddleware
{
    private readonly RequestDelegate Next;
    private readonly IReporterService Reporter;

    public ExceptionMiddleware(RequestDelegate next, IReporterService reporter)
    {
        Next = next;
        Reporter = reporter;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await Next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = Convert.ToInt32(exception.Message.Split("|")[0]);

        if (context.Response.StatusCode == 500) Reporter.SendMessage(500, "", exception);

        await context.Response.WriteAsync(new ErrorModel(context.Response.StatusCode, exception.Message.Split("|")[1]).ToString());
    }
}