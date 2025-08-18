namespace AdvertisingPlatformsSystem.Domain;

public class AgentInfo
{
    public long Id { get; set; }
    public string Name { get; set; }
    public ICollection<string> Locations { get; set; }
}