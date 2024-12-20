using eCommerce.Core.Contracts;
using eCommerce.Core.DTO;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersControllers(IUsersService usersService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest? registerRequest)
    {
        if (registerRequest is null)
            return BadRequest();

        var response = await usersService.RegisterAsync(registerRequest);

        if (response is not { Success: not false })
            return BadRequest(response);

        return Ok(response);
    }

    [HttpPost("login")] 
    public async Task<IActionResult> Login(LoginRequest? loginRequest)
    {
        if (loginRequest is null)
            return BadRequest();

        var response = await usersService.LoginAsync(loginRequest);

        if (response is not { Success: not false })
            return Unauthorized(response);

        return Ok(response);
    }

}