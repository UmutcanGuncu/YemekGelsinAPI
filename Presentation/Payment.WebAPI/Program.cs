using MassTransit;
using Microsoft.EntityFrameworkCore;
using Order.Application.Abstractions.Services;
using Payment.Persistence.Contexts;
using Payment.Persistence.Services;
using Payment.WebAPI.Consumers;
using Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMassTransit(configure =>
{
    configure.AddConsumer<OrderCreatedEventConsumer>();
    configure.UsingRabbitMq((context, _cfg) =>
    {
        _cfg.Host(builder.Configuration["RabbitMQ"]);
        _cfg.ReceiveEndpoint(RabbitMQSettings.Payment_OrderCreatedEventQueue, e=> 
            e.ConfigureConsumer<OrderCreatedEventConsumer>(context));
    });
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PaymentDbContext>(cfg => 
    cfg.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IPaymentService, PaymentService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();