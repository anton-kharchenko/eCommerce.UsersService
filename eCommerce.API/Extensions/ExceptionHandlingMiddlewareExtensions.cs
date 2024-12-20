namespace eCommerce.API.Middlewares;

public static class ExceptionHandlingMiddlewareExtensions
{
    public static void UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
    {
        builder.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}