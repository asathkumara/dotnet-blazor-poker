using DotnetBlazorPoker.App;
using DotnetBlazorPoker.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<GameStateManager>();
//await builder.Build().RunAsync();

var host = builder.Build();
await ElementReferenceExtensions.Initialize(host.Services.GetRequiredService<IJSRuntime>());
await Window.Initialize(host.Services.GetRequiredService<IJSRuntime>());

await host.RunAsync();
