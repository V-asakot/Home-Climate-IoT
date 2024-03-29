using HomeIoTDevices.Service.Data;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using HomeIoTDevices.Service.Consumers.DeviceInitializedConsumer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(x =>
{
    var rabbitConnectionString = builder.Configuration.GetSection("RabbitMqSettings")["ConnectionString"];
    x.SetKebabCaseEndpointNameFormatter();
    x.AddConsumer<DeviceInitializedConsumer, DeviceInitializedConsumerDefinition>();
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(rabbitConnectionString);
        cfg.ConfigureEndpoints(context);
    });

    x.AddEntityFrameworkOutbox<ApplicationDbContext>(o =>
    {
        o.QueryDelay = TimeSpan.FromSeconds(1);

        o.UsePostgres();
        o.UseBusOutbox();
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

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
    });

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
