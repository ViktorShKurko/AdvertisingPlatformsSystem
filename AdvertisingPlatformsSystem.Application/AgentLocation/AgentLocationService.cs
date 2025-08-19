using AdvertisingPlatformsSystem.Domain;
using AdvertisingPlatformsSystem.Dto;
using AdvertisingPlatformsSystem.Helpers;

namespace AdvertisingPlatformsSystem.AgentLocation;

public class AgentLocationService :IAgentLocationService
{
    private readonly IAgentLocationRepository _repository;

    public AgentLocationService(IAgentLocationRepository agentLocationRepository)
    {
        _repository = agentLocationRepository;
    }

    public UploadDto UploadAgentLocationData(byte[] fileData)
    {
        var agentLocationDataRows = FileReaderHelprer.GetAllLinesFromByteArray(fileData);
        var agentsList = new Dictionary<string, AgentInfo>();
        var uploadDto = new UploadDto();

        foreach (var agentLocationDataRow in agentLocationDataRows)
        {
            AgentInfo agentInfo = null;
            try
            {
                agentInfo = CustomFormatConverter.Deserialize(agentLocationDataRow);
            }
            catch(Exception ex)
            {
                uploadDto.TotalFail++;
                uploadDto.Errors.Add(ex.Message);
                continue;
            }

            var existAgentInfo = agentsList.GetValueOrDefault(agentInfo.Name);
            
            if (existAgentInfo == null)
            {
                agentsList.Add(agentInfo.Name, agentInfo);
            }
            else
            {
                existAgentInfo.Locations.AddRange(agentInfo.Locations);
            }
            
            uploadDto.TotalLoaded++;
        } 
        
        _repository.Update(agentsList.Values.ToArray());
        return uploadDto;
    }

    public IEnumerable<string> GetAgentsByLocations(string location)
    {
        return _repository.GetAgentsByLocation(location).Select(x => x.Name);
    }
}