using BackendEvaluation.Infrastructure;
using BackendEvaluation.Core;
using Serilog;
using BackendEvaluation.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services
    .AddInfrastructure()
    .AddCore()
    .AddDomain();

builder.Host.UseSerilog((context, Configuration) => Configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();

app.Run();
