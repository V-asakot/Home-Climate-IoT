using MassTransit;
using Microsoft.EntityFrameworkCore;
using RoomsClimate.Service.Consumers.ClimateMeasured;
using RoomsClimate.Service.Consumers.DeviceAdded;
using RoomsClimate.Service.Consumers.RoomAdded;
using RoomsClimate.Service.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(x =>
{
    x.SetKebabCaseEndpointNameFormatter();
    x.AddConsumer<ClimateMeasuredConsumer, ClimateMeasuredConsumerDefinition>();
    x.AddConsumer<DeviceAddedEventConsumer>();
    x.AddConsumer<RoomAddedEventConsumer>();
    var rabbitConnectionString = builder.Configuration.GetSection("RabbitMqSettings")["ConnectionString"];

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(rabbitConnectionString);
        cfg.ConfigureEndpoints(context);
    });
});

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("Development", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddMediatR(x =>
{
    x.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddMemoryCache();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Docker"))
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("Development");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
