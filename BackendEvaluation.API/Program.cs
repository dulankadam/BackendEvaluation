using BackendEvaluation.Api.Services;
using BackendEvaluation.API.Extensions;
using BackendEvaluation.Core;
using BackendEvaluation.Core.Common.Interfaces;
using BackendEvaluation.Domain;
using BackendEvaluation.Infrastructure;
using BackendEvaluation.Infrastructure.Persistence;
using IdentityModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Serilog;

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
builder.Services.AddScoped<RequestLoggingActivityAttribute>();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "oidc";
})
    .AddCookie("Cookies")
    .AddOpenIdConnect("oidc", options =>
    {
        options.Authority = "https://localhost:5001";

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            RoleClaimType = "UserRole",
            NameClaimType = JwtClaimTypes.Name,

        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", new string[] { "BackendEvaluation.Api", "role", "openid", "profile" });

    });

    options.AddPolicy("UserPolicy", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", new string[] { "BackendEvaluation.Api", "role", "openid", "profile" });
        policy.RequireClaim("UserRole", "User");

    });

    options.AddPolicy("AuditorPolicy", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", new string[] { "BackendEvaluation.Api", "role", "openid", "profile" });
        policy.RequireClaim("AuditorRole", "Auditor");

    });
});

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
app.UseAuthentication();

app.MapControllers();

app.Run();
