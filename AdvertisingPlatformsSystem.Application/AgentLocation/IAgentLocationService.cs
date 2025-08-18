namespace AdvertisingPlatformsSystem.AgentLocation;


public interface IAgentLocationService
{
    void UploadAgentLocationData(byte[] data);
    IEnumerable<string> GetAgentsByLocations(string location);
}