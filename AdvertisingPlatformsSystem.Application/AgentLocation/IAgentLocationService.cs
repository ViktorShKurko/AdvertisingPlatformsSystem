namespace AdvertisingPlatformsSystem.AgentLocation;

public interface IAgentLocationService
{
    void UpdateAgentLocationData(byte[] data);
    IEnumerable<string> GetAgentsByLocations(string location);
}