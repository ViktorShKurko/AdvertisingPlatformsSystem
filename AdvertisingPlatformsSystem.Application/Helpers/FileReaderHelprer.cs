using System.Text;

namespace AdvertisingPlatformsSystem.Helpers;

public class FileReaderHelprer
{
    public static IEnumerable<string> GetAllLinesFromByteArray(byte[] fileData) 
    {
        using var memoryStream = new MemoryStream(fileData);
        using var sr = new StreamReader(memoryStream, Encoding.UTF8);

        string? line;
        var lines = new List<string>();

        while ((line = sr.ReadLine()) != null)
        {
            lines.Add(line);
        }

        return lines;
    }
}