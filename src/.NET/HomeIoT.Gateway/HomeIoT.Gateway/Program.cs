var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("Development", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var roomClimateUrl = builder.Configuration["Services:RoomClimate:Url"];
builder.Services.AddHttpClient("roomClimate", (serviceProvider,httpClient) =>
    {
        httpClient.BaseAddress = new Uri(roomClimateUrl!);
    });

var homeIoTDevicesUrl = builder.Configuration["Services:HomeIoTDevices:Url"];
builder.Services.AddHttpClient("homeIoTDevices", (serviceProvider,httpClient) =>
    {
        httpClient.BaseAddress = new Uri(homeIoTDevicesUrl!);
    });

builder.Services.AddScoped<ClimateService>();
builder.Services.AddScoped<DevicesService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Docker"))
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("Development");
}

app.UseHttpsRedirection();

app.MapEndpoints();

app.Run();