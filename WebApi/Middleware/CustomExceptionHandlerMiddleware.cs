using System.Net;
using System.Text.Json;

namespace WebApi.Middleware
{
    public class CustomExceptionHandlerMiddleware(RequestDelegate next)
    {
        public readonly RequestDelegate _next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception exception)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var result = JsonSerializer.Serialize(exception.Message);

                await context.Response.WriteAsync(result);
            }
        }
    }
}
