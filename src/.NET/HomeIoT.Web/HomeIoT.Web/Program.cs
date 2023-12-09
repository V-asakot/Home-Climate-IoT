using HomeIoT.Web;
using HomeIoT.Web.Services.DevicesDataProviders;
using HomeIoT.Web.Services.RoomDevicesService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var gatewayUrl = builder.Configuration["Services:Gateway:Url"];
builder.Services.AddHttpClient("gateway", (serviceProvider, httpClient) =>
    {
        httpClient.BaseAddress = new Uri(gatewayUrl!);
    });

builder.Services.AddTransient<DevicesDataProvider,ThermostatsDataProvider>();
builder.Services.AddTransient<DevicesDataProvider,ClimateSensorsDataProvider>();
builder.Services.AddScoped<RoomDevicesProviderService>();

await builder.Build().RunAsync();
