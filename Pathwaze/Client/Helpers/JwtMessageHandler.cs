using System.Net.Http.Headers;

namespace Pathwaze.Client.Helpers;

public class JwtMessageHandler : DelegatingHandler
{
    private readonly CustomAuthStateProvider _customAuthStateProvider;

    public JwtMessageHandler(CustomAuthStateProvider customAuthStateProvider)
    {
        _customAuthStateProvider = customAuthStateProvider;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var token = await _customAuthStateProvider.GetTokenAsync();

        if (!string.IsNullOrEmpty(token))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        return await base.SendAsync(request, cancellationToken);
    }
}

