using eCommerce.Core.Contracts;
using eCommerce.Infrastructure.DbContext;
using eCommerce.Infrastructure.Repositories;
using eCommerce.Infrastructure.Services;
using eCommerce.Infrastructure.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IUsersRepository, UsersRepository>();
        services.AddTransient<IUsersService, UsersService>();
        services.AddTransient<DapperDbContext>();
        services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
    }
}