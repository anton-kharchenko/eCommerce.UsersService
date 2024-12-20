using AutoMapper;
using eCommerce.Core.Contracts;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;

namespace eCommerce.Infrastructure.Services;

internal class UsersService(IUsersRepository usersRepository, IMapper mapper) : IUsersService
{
    public async Task<AuthenticationResponse?> LoginAsync(LoginRequest? loginRequest)
    {
        var user = await usersRepository.GetUserByEmailAnyPasswordAsync(loginRequest.Email, loginRequest.Password);
        return user == null ? null : mapper.Map<AuthenticationResponse>(user) with { Success = true, Token = "token" };
    }

    public async Task<AuthenticationResponse?> RegisterAsync(RegisterRequest? registerRequest)
    {
        var user = new ApplicationUser
        {
            Email = registerRequest.Email,
            Gender = registerRequest.GenderOptions.ToString(),
            Password = registerRequest.Password,
            PersonName = registerRequest.PersonName
        };

        user = await usersRepository.AddUserAsync(user);
        return user == null ? null : mapper.Map<AuthenticationResponse>(user) with { Success = true, Token = "token" };
    }
}