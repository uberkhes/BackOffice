using BackOffice.Domain.Entities.Users;
using Microsoft.AspNetCore.Mvc;
using BackOffice.Domain.Interfaces.Users;
using BackOffice.Application.Test;
using BackOffice.Domain.Interfaces;

namespace BackOffice.Controllers;

[Route("api/Users")]
public class UserController(IUsersService usersService, ITestManager testManager) : ControllerBase
{
    private readonly IUsersService _usersService = usersService;
    private readonly ITestManager _testManager = testManager;

    [Route("GetUsers")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<List<User>> GetUsers()
    {
        var test = _testManager.GetDocs();
        var users = await _usersService.GetAsync();
        return users;
    }
}

