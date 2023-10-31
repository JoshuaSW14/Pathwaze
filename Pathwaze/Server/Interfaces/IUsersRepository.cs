namespace Pathwaze.Server.Interfaces;

public interface IUsersRepository
{
    public Task<User> Register(UserDto userDto);
    public Task<JwtSecurityToken> Login(LoginDto loginDto);
}

