using System;
using System.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Pathwaze.Server.Interfaces;

namespace Pathwaze.Server.Repositories;

public class UsersRepository : IUsersRepository
{
	private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;
    private readonly IServiceProvider _serviceProvider;

    public UsersRepository(AppDbContext context, IConfiguration configuration, IServiceProvider serviceProvider)
	{
		_context = context;
        _configuration = configuration;
        _serviceProvider = serviceProvider;
    }

	public async Task<User> Register(UserDto userDto)
	{
		try
		{
            if (await UserExists(userDto.Email!))
            {
                return null!;
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(userDto.Password);

            User user = new User()
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                UserName = userDto.Email,
                PhoneNumber = userDto.PhoneNumber,
                PasswordHash = hashedPassword
            };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            var roleManager = _serviceProvider.GetService<RoleManager<IdentityRole>>();
            var role = "User";

            IdentityResult IR;
            if (!await roleManager.RoleExistsAsync(role))
            {
                IR = await roleManager.CreateAsync(new IdentityRole(role));
            }

            var userManager = _serviceProvider.GetService<UserManager<User>>();
            IR = await userManager.AddToRoleAsync(user, role);

            return user;
        }
        catch(Exception ex)
		{
            Console.WriteLine("Error Occurred in the Register Repository: " + ex.Message);
        }
		return null!;
	}

	public async Task<JwtSecurityToken> Login(LoginDto loginDto)
	{
		try
		{
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Username);
            if (user == null)
            {
                return null!;
            }

            bool validPassword = BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash);
            if (!validPassword)
            {
                return null!;
            }

            var userManager = _serviceProvider.GetService<UserManager<User>>();
            var roles = await userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                //... other token properties like expiration, signing credentials, etc.
            };

            //var tokenHandler = new JwtSecurityTokenHandler();
            //var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            //var jwtToken = tokenHandler.WriteToken(securityToken);

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
            return token;
        }
        catch(Exception ex)
		{
            Console.WriteLine("Error Occurred in the Login Repository: " + ex.Message);
		}
		return null!;
	}

    private async Task<bool> UserExists(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user != null)
            return true;
        return false;
    }
}

