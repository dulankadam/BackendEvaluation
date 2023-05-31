using BackendEvaluation.Core.Common.Interfaces;
using BackendEvaluation.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace BackendEvaluation.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var useInMemory = configuration.GetValue<bool>("UseInMemoryDatabase");

        if (useInMemory)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("Test"));
        }
        else
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("Default")
                );
                options.EnableSensitiveDataLogging(true);
            });
        }

        services.AddSingleton<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

        return services;
    }
}