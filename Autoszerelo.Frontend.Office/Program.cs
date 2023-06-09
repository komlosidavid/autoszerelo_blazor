using autoszerelo_frontend_office;
using autoszerelo_frontend_office.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<WorkService>();
builder.Services.AddScoped<ClientService>();
builder.Services.AddScoped<CarService>();

await builder.Build().RunAsync();
