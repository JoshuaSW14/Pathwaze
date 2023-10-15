using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Pathwaze.Server.Data;
using Pathwaze.Shared.Models.Dtos;
using Pathwaze.Shared.Models.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Pathwaze.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;

    public UsersController(AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginUser)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginUser.Username);
        if (user == null)
        {
            return BadRequest("Invalid email or password.");
        }

        bool validPassword = BCrypt.Net.BCrypt.Verify(loginUser.Password, user.PasswordHash);
        if (!validPassword)
        {
            return BadRequest("Invalid email or password.");
        }

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Email!),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = _configuration["JwtSettings:Key"]!.ToString();

        var token = new JwtSecurityToken
        (
            issuer: _configuration["JwtSettings:Issuer"],
            audience: _configuration["JwtSettings:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddDays(1),
            notBefore: DateTime.UtcNow,
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                    SecurityAlgorithms.HmacSha256)
        );
        return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserDto userDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if(await UserExists(userDto.Email!))
        {
            return BadRequest(ModelState);
        }

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(userDto.Password);

        User user = new User()
        {
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            Email = userDto.Email,
            PhoneNumber = userDto.PhoneNumber,
            PasswordHash = hashedPassword
        };

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return Ok(new { Message = "User created successfully.", UserId = user.Id });
    }

    private async Task<bool> UserExists(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user != null)
            return true;
        return false;
    }
}
