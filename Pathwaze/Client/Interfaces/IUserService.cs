using Pathwaze.Shared.Models.Dtos;
namespace Pathwaze.Client.Interfaces;

public interface IUserService
{
    public Task<bool> Login(LoginDto user);

    public Task<bool> Register(UserDto user);
}
