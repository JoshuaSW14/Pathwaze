using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Pathwaze.Client;
using Pathwaze.Client.AuthProviders;
using Pathwaze.Client.Interfaces;
using Pathwaze.Client.Services;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<CustomAuthStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<CustomAuthStateProvider>());
//builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
//builder.Services.AddScoped<AuthenticationService>();

builder.Services.AddAuthorizationCore();

builder.Services.AddHttpClient<IUserService, UserService>("UserService", client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress + "api/Users");
});//.AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("UserService"));

builder.Services.AddRadzenComponents();

await builder.Build().RunAsync();
