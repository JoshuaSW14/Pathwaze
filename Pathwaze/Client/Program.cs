using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Pathwaze.Client;
using Pathwaze.Client.Interfaces;
using Pathwaze.Client.Services;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddHttpClient<IUserService, UserService>("UserService", client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress + "api/Users");
});//.AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("UserService"));

builder.Services.AddRadzenComponents();

await builder.Build().RunAsync();
