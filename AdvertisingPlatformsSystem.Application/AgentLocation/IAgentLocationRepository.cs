using AdvertisingPlatformsSystem.Domain;

namespace AdvertisingPlatformsSystem.AgentLocation;

public interface IAgentLocationRepository
{
    IEnumerable<AgentInfo> GetAgentsByLocation();
    void Update(IEnumerable<AgentInfo> agentIds);
}