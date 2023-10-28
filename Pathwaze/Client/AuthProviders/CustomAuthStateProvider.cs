using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using Pathwaze.Client.Services;
using System.Security.Claims;
using System.Text.Json;

namespace Pathwaze.Client.AuthProviders;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
    //private AuthenticationState authenticationState;
    private readonly IJSRuntime _jsRuntime;

    public CustomAuthStateProvider(IJSRuntime jsRuntime) //AuthenticationService service, 
    {
        _jsRuntime = jsRuntime;
        //authenticationState = new AuthenticationState(service.CurrentUser);

        //service.UserChanged += (newUser) =>
        //{
        //    authenticationState = new AuthenticationState(newUser);

        //    NotifyAuthenticationStateChanged(
        //        Task.FromResult(new AuthenticationState(newUser)));
        //};
    }

    //public override Task<AuthenticationState> GetAuthenticationStateAsync() =>
    //    Task.FromResult(authenticationState);

    public async Task<string> GetTokenAsync()
            => await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "authToken");

    public async Task SetTokenAsync(string token)
    {
        if (token == null)
        {
            await _jsRuntime.InvokeAsync<object>("localStorage.removeItem", "authToken");
        }
        else
        {
            await _jsRuntime.InvokeAsync<object>("localStorage.setItem", "authToken", token);
        }

        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var token = await GetTokenAsync();
        var identity = string.IsNullOrEmpty(token)
            ? new ClaimsIdentity()
            : new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");
        return new AuthenticationState(new ClaimsPrincipal(identity));
    }

    public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        var payload = jwt.Split('.')[1];
        var jsonBytes = ParseBase64WithoutPadding(payload);
        var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
        return keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
    }

    private static byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }
        return Convert.FromBase64String(base64);
    }
}

