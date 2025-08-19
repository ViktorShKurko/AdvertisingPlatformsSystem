using AdvertisingPlatformsSystem.Domain;
using AdvertisingPlatformsSystem.Exceptions;

namespace AdvertisingPlatformsSystem.Helpers;

public class CustomFormatConverter
{
    public static AgentInfo Deserialize(string line)
    {
        ThrowHelper.ThrowIfRowNullOrInvalidFormat(line);

        var splitLine = line.Split(':');
        var agentName = splitLine[0].Trim();
        var locations = splitLine[1].Split(',',StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
       
        if (locations.Length == 0)
            throw new InvalidRowFormatException($"{agentName} does not contain any locations.");
        
        foreach (var location in locations)
        {
            ThrowHelper.ThrowIfInvalidLocation(location);
        }

        return new AgentInfo(agentName, locations.ToList());
    }
}