namespace AdvertisingPlatformsSystem;

public class AgentInfo
{
    public long Id { get; set; }
    public string Name { get; set; }
    ICollection<string> Locations { get; set; }
}