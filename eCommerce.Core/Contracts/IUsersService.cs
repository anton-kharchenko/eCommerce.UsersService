using eCommerce.Core.DTO;

namespace eCommerce.Core.Contracts;

public interface IUsersService
{
    Task<AuthenticationResponse?> LoginAsync(LoginRequest? loginRequest);
    
    Task<AuthenticationResponse?> RegisterAsync(RegisterRequest? registerRequest);
}