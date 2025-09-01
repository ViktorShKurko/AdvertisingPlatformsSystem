namespace AdvertisingPlatformsSystem.Core.Models;

/// <summary>
/// Сущность рекламный агент.
/// </summary>
public class AgentInfo
{
    private static long _generatedId = 0;
    private long _id;
    
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public long Id => _id;
    
    /// <summary>
    /// Наименование агента.
    /// </summary>
    public string Name { get; private set; }
    
    /// <summary>
    /// Спиок локаций.
    /// </summary>
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