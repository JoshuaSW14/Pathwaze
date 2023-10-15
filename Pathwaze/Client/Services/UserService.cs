using Newtonsoft.Json;
using Pathwaze.Client.Interfaces;
using Pathwaze.Shared.Models.Dtos;
using System.Text;

namespace Pathwaze.Client.Services;

public class UserService : IUserService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<UserService> _logger;

    public UserService(HttpClient httpClient, ILogger<UserService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<bool> Login(LoginDto user)
    {
        try
        {
            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Post, $"{_httpClient.BaseAddress!.AbsoluteUri}/Login");
            string jsonRequest = JsonConvert.SerializeObject(user);
            httpRequest.Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(httpRequest);
            if (response.IsSuccessStatusCode)
                return true;

        }catch (Exception ex)
        {
            _logger.LogError(ex, "UserService.Login failed with: " + ex.Message);
        }
        return false;
    }

    public async Task<bool> Register(UserDto user)
    {
        try
        {
            HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Post, $"{_httpClient.BaseAddress!.AbsoluteUri}/Register");
            string jsonRequest = JsonConvert.SerializeObject(user);
            httpRequest.Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(httpRequest);
            if (response.IsSuccessStatusCode)
                return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "UserService.Register failed with: " + ex.Message);
        }
        return false;
    }
}
