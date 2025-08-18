using AdvertisingPlatformsSystem.Domain;
using AdvertisingPlatformsSystem.Helpers;

namespace AdvertisingPlatformsSystem.AgentLocation;

public class AgentLocationService :IAgentLocationService
{
    private readonly IAgentLocationRepository _repository;

    public AgentLocationService(IAgentLocationRepository agentLocationRepository)
    {
        _repository = agentLocationRepository;
    }

    public void UploadAgentLocationData(byte[] fileData)
    {
        var agentLocationDataRows = FileReaderHelprer.GetAllLinesFromByteArray(fileData);
        var agentsList = new Dictionary<string, AgentInfo>();
        foreach (var agentLocationDataRow in agentLocationDataRows)
        {
            var agentInfo = CustomFormatConverter.Desirilealise(agentLocationDataRow);
            var d = agentsList.GetValueOrDefault(agentInfo.Name);
            if (d == null)
            {
                agentsList.Add(agentInfo.Name, agentInfo);
            }
            else
            {
                d.Locations.AddRange(agentInfo.Locations);
            }
        }
            
        _repository.Update(agentsList.Values.ToArray());
    }

    public IEnumerable<string> GetAgentsByLocations(string location)
    {
        return _repository.GetAgentsByLocation(location).Select(x => x.Name);
    }
}