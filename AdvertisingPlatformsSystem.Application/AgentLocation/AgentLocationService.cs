using AdvertisingPlatformsSystem.Core.Containers;
using AdvertisingPlatformsSystem.Core.Models;
using AdvertisingPlatformsSystem.Dto;
using AdvertisingPlatformsSystem.Helpers;

namespace AdvertisingPlatformsSystem.AgentLocation;

/// <summary>
/// <inheritdoc cref="IAgentLocationService"/>
/// </summary>
public class AgentLocationService :IAgentLocationService
{
    private readonly AgentLocationMapTree _tree = new();

    public UploadDto UploadAgentLocationData(byte[] fileData)
    {
        var agentLocationDataRows = FileReaderHelper.GetAllLinesFromByteArray(fileData);
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
        
        _tree.SetAgentLocationsData(agentsList.Values.ToArray());
        return uploadDto;
    }

    public IEnumerable<string> GetAgentsByLocations(string location)
    {
        return _tree.GetAgentsByLocation(location).Select(x => x.Name);
    }
}