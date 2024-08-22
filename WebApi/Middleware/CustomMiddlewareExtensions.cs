namespace WebApi.Middleware
{
    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(
            this IApplicationBuilder builder) =>
            builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
    }
}
