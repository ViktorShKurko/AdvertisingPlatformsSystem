using AdvertisingPlatformsSystem.AgentLocation;
using AdvertisingPlatformsSystem.Domain;
using AdvertisingPlatformsSystem.Domain.Containers;
using AdvertisingPlatformsSystem.Domain.Models;

namespace AdvertisingPlatformsSystem.Repositories;

public class AgentLocationTreeMapRepository : IAgentLocationRepository
{
    private readonly AgentLocationMapTree _tree;
    public AgentLocationTreeMapRepository()
    {
        _tree = new AgentLocationMapTree();
    }

    public IEnumerable<AgentInfo> GetAgentsByLocation(string location)
    {
        return _tree.GetAgentsByLocation(location);
    }

    public void Update(IEnumerable<AgentInfo> agentDataList)
    {
        _tree.SetAgentLocationsData(agentDataList);
    }
}