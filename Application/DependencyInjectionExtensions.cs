using Application.Services;
using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjectionExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IPersonApplicationService, PersonApplicationService>();
        services.AddScoped<IPhoneApplicationService, PhoneApplicationService>();
    }
}