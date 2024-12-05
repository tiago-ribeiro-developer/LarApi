using Domain.Interfaces.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjectionExtensions
{
    public static void AddInfraRepositoryServices(this IServiceCollection services)
    {
        //Infra - Contexts
        services.AddScoped<LarContext>();

        // Infra - Data
        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<IPhoneRepository, PhoneRepository>();
    }
}