using AdvertisingPlatformsSystem.Domain;

namespace AdvertisingPlatformsSystem.Helpers;

public class CustomFormatConverter
{
    public static AgentInfo Desirilealise(string line)
    {
        if (string.IsNullOrEmpty(line) || string.IsNullOrWhiteSpace(line) || !line.Contains(':'))
        {
            Console.WriteLine($"Invalid input row: {line}");    
        }
            
        var splitLine = line.Split(':');
        if (splitLine.Length != 2)
            Console.WriteLine($"Invalid input row: {line}");
            
        var agentName = splitLine[0];
        var location = splitLine[1].Split(',');

        if (location.Length == 0)
            Console.WriteLine($"Invalid input row: {line}");
            
            
        return new AgentInfo()
        {
            Name = agentName,
            Locations = location.ToList(),
        };
    }
}