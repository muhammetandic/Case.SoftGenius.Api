using Case.SoftGenius.Api.Application.Abstractions.Data;
using Case.SoftGenius.Api.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Case.SoftGenius.Api.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}
