using Microsoft.Extensions.DependencyInjection;
using Pathwaze.Server.Interfaces;

namespace Pathwaze.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsersRepository _usersRepository;
    
    public UsersController(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginUser)
    {
        var response = await _usersRepository.Login(loginUser);
        if(response is not null)
            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(response) });
        return BadRequest();
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserDto userDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        else
        {
            var response = await _usersRepository.Register(userDto);
            if (response is not null)
                return Ok(true);
        }
        return BadRequest();
    }

    
}
