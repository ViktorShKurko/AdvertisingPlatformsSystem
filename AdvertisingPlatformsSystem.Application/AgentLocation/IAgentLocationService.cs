using AdvertisingPlatformsSystem.Dto;

namespace AdvertisingPlatformsSystem.AgentLocation;


public interface IAgentLocationService
{
    UploadDto UploadAgentLocationData(byte[] data);
    IEnumerable<string> GetAgentsByLocations(string location);
}