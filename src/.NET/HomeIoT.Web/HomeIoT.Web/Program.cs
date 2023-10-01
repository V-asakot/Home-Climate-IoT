using HomeIoT.Web;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var roomClimateUrl = builder.Configuration["Services:RoomClimate:Url"];
builder.Services.AddHttpClient("roomClimate", (serviceProvider,httpClient) =>
    {
        httpClient.BaseAddress = new Uri(builder.Configuration["Services:RoomClimate:Url"]!);
    });

builder.Services.AddHttpClient("homeIoTDevices", (serviceProvider,httpClient) =>
    {
        httpClient.BaseAddress = new Uri(builder.Configuration["Services:HomeIoTDevices:Url"]!);
    });

await builder.Build().RunAsync();
