namespace AdvertisingPlatformsSystem.Domain;

public class AgentInfo
{
    private static long _generatedId = 0;
    private long _id;
    public long Id => _id;
    public string Name { get; set; }
    public List<string> Locations { get; set; }

    public AgentInfo()
    {
        _id = _generatedId++;
    }
}