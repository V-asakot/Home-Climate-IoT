using MassTransit;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using RoomsClimate.Service.Consumers.ClimateMeasured;
using RoomsClimate.Service.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<ClimateMeasuredConsumer, ClimateMeasuredConsumerDefinition>();

    var rabbitConnectionString = builder.Configuration.GetSection("RabbitMqSettings")["ConnectionString"];
    x.UsingRabbitMq ((context, cfg) =>
    {
        cfg.Host(rabbitConnectionString);
        cfg.ConfigureEndpoints(context);
    });  
});
builder.Services.AddMediatR(x =>
{
    x.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddDistributedMemoryCache();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder.AllowAnyOrigin()
                             .AllowAnyHeader()
                            .AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
