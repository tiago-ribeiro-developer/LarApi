using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Domain;

public static class DependencyInjectionExtensions
{
    public static void AddDomainServices(this IServiceCollection services)
    {
        // Domain - Commands
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(
                Assembly.Load("Application"),
                Assembly.Load("Api"),
                Assembly.Load("Infrastructure"),
                Assembly.Load("Domain"));
        });
    }
}