var builder = WebApplication.CreateBuilder(args);

var roomClimateUrl = builder.Configuration["Services:RoomClimate:Url"];
builder.Services.AddHttpClient("roomClimate", (serviceProvider,httpClient) =>
    {
        httpClient.BaseAddress = new Uri(builder.Configuration["Services:RoomClimate:Url"]!);
    });
builder.Services.AddScoped<ClimateService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapEndpoints();

app.Run();