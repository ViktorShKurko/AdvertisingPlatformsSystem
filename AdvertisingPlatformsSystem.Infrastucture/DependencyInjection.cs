using AdvertisingPlatformsSystem.AgentLocation;
using AdvertisingPlatformsSystem.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AdvertisingPlatformsSystem;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastucture(this IServiceCollection services)
    {
        services.AddSingleton<IAgentLocationRepository, AgentLocationTreeMapRepository>();
        return services;
    }
}