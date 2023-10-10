using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Pathwaze.Server.Data;
using Pathwaze.Server.Helpers;
using Pathwaze.Shared.Models.Dtos;
using Pathwaze.Shared.Models.Entities;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Pathwaze.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly JwtUtils _jwtUtils;
    private readonly IConfiguration _configuration;

    public UsersController(AppDbContext context, JwtUtils jwtUtils, IConfiguration configuration)
    {
        _context = context;
        _jwtUtils = jwtUtils;
        _configuration = configuration;
    }

    [HttpGet("login")]
    public async Task<IActionResult> Login(string email, string password)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user == null)
        {
            return BadRequest("Invalid email or password.");
        }

        bool validPassword = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
        if (!validPassword)
        {
            return BadRequest("Invalid email or password.");
        }

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            // Add other claims as necessary
        };

        var token = new JwtSecurityToken
        (
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddDays(1),
            notBefore: DateTime.UtcNow,
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),
                    SecurityAlgorithms.HmacSha256)
        );
        return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        //var token = _jwtUtils.GenerateToken(user, roles);
        //return Ok(user);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserDto userDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if(await UserExists(userDto.Email))
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

    [HttpPut("update/{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UserDto userDto)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound("User not found.");
        }

        user.FirstName = userDto.FirstName;
        user.LastName = userDto.LastName;
        user.Email = userDto.Email;

        _context.Users.Update(user);
        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound("User not found.");
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return Ok();
    }

    private async Task<bool> UserExists(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user != null)
            return true;
        return false;
    }
}
