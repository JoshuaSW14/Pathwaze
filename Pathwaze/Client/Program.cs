var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<StateContainer>();
builder.Services.AddScoped<CustomAuthStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<CustomAuthStateProvider>());
builder.Services.AddTransient<JwtMessageHandler>();
builder.Services.AddAuthorizationCore();

builder.Services.AddHttpClient<IUserService, UserService>("UserService", client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress + "api/Users");
}).AddHttpMessageHandler<JwtMessageHandler>(); //.AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("UserService"));

builder.Services.AddHttpClient<IProductService, ProductService>("ProductService", client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress + "api/Products");
}).AddHttpMessageHandler<JwtMessageHandler>();
builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ProductService"));

builder.Services.AddRadzenComponents();

await builder.Build().RunAsync();