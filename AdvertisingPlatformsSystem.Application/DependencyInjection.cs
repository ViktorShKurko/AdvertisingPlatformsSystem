using AdvertisingPlatformsSystem.AgentLocation;
using Microsoft.Extensions.DependencyInjection;

namespace AdvertisingPlatformsSystem;

public static class DependencyInjection
{
    public static IServiceCollection AddApplications(this IServiceCollection services)
    {
        services.AddScoped<IAgentLocationService, AgentLocationService>();
        return services;
    }
}