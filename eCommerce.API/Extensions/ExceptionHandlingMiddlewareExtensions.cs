using eCommerce.API.Middlewares;

namespace eCommerce.API.Extensions;

public static class ExceptionHandlingMiddlewareExtensions
{
    public static void UseExceptionHandlingMiddleware(this IApplicationBuilder builder) =>
        builder.UseMiddleware<ExceptionHandlingMiddleware>();
}