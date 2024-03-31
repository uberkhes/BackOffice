using BackOffice.Domain.Entities.Users;
using Microsoft.AspNetCore.Mvc;
using BackOffice.Domain.Interfaces.Users;

namespace BackOffice.Controllers;

[Route("api/Users")]
public class UserController(IUsersService usersService) : ControllerBase
{
    private readonly IUsersService _usersService = usersService;

    [Route("GetUsers")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<List<User>> GetUsers()
    {
        var users = await _usersService.GetAsync();
        return users;
    }
}

