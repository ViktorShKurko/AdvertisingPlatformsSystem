using AdvertisingPlatformsSystem.Domain;

namespace AdvertisingPlatformsSystem.AgentLocation;

public interface IAgentLocationRepository
{
    IEnumerable<AgentInfo> GetAgentsByLocation(string location);
    void Update(IEnumerable<AgentInfo> agentDataList);
}