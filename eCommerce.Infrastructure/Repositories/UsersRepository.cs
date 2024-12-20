using Dapper;
using eCommerce.Core.Contracts;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Infrastructure.DbContext;

namespace eCommerce.Infrastructure.Repositories;

internal class UsersRepository(DapperDbContext dbContext) : IUsersRepository
{
    const string insertNewUserQuery =
        "INSERT INTO public.\"Users\" (\"UserId\", \"PersonName\", \"Email\", \"Password\", \"Gender\") VALUES (@UserId, @PersonName, @Email, @Password, @Gender)";
    const string selectUserByEmailAndPasswordQuery =
        "SELECT * FROM \"public.\"Users\" WHERE \"Email\" = @Email AND \"Password\" = @Password";
    public async Task<ApplicationUser?> AddUserAsync(ApplicationUser user)
    {
        user.UserId = Guid.NewGuid();
        var affectedRows = await dbContext.DbConnection.ExecuteAsync(insertNewUserQuery, user);
        return affectedRows > 0 ? user : null;
    }

    public async Task<ApplicationUser?> GetUserByEmailAnyPasswordAsync(string? email, string? password) =>
        await dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(selectUserByEmailAndPasswordQuery);
}