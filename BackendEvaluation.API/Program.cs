using BackendEvaluation.API.Extensions;
using BackendEvaluation.Core;
using BackendEvaluation.Domain;
using BackendEvaluation.Infrastructure;
using Serilog;
using System.Configuration;



var builder = WebApplication.CreateBuilder(args);
IConfiguration Configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureAuthService(Configuration);

builder.Host.UseSerilog((context, Configuration) => Configuration.ReadFrom.Configuration(context.Configuration));

builder.Services
    .AddInfrastructure(Configuration)
    .AddCore()
    .AddDomain();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
