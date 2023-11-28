namespace Pathwaze.Client.AuthProviders;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
    private readonly IJSRuntime _jsRuntime;
    private readonly StateContainer _stateContainer;

    public CustomAuthStateProvider(IJSRuntime jsRuntime, StateContainer stateContainer)
    {
        _jsRuntime = jsRuntime;
        _stateContainer = stateContainer;
    }

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
        if (string.IsNullOrEmpty(token))
        {
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        var claims = ParseClaimsFromJwt(token);
        _stateContainer.SetGroceryIdFromClaims(claims);
        
        var identity = new ClaimsIdentity(claims, "jwt");

        return new AuthenticationState(new ClaimsPrincipal(identity));
    }

    public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        var payload = jwt.Split('.')[1];
        var jsonBytes = ParseBase64WithoutPadding(payload);
        var keyValuePairs = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
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

