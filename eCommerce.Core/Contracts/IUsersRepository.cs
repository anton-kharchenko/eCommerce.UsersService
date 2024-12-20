using eCommerce.Core.Entities;

namespace eCommerce.Core.Contracts;

public interface IUsersRepository
{
    Task<ApplicationUser?> AddUserAsync(ApplicationUser user);
    
    Task<ApplicationUser?> GetUserByEmailAnyPasswordAsync(string? email, string? password);
}