namespace AdvertisingPlatformsSystem.Domain;

public class AgentInfo
{
    private static long _generatedId = 0;
    private long _id;
    public long Id => _id;
    public string Name { get; private set; }
    public List<string> Locations { get; private set; }

    public AgentInfo(string name , List<string> locations)
    {
        ThrowIfNameIsEmpty(name);
        
        _id = _generatedId++;
        Locations = locations;
        Name = name;
    }

    private static void ThrowIfNameIsEmpty(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException($"Name is empty or whitespace: {name}");
    }
}