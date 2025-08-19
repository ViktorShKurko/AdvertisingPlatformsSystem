using System.Text.RegularExpressions;
using AdvertisingPlatformsSystem.Exceptions;

namespace AdvertisingPlatformsSystem.Helpers;

internal static class ThrowHelper
{
    private static readonly Regex _locationPattern = new Regex(@"^(/[a-zA-Z0-9]+)+$",
        RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);
    
    private static readonly Regex _agentPattern = new Regex(@"^[a-zA-ZА-Яа-я0-9._ -]+:[a-zA-Z0-9,/]+$",
        RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);
    
    public static void ThrowIfRowNullOrInvalidFormat(string row)
    {
        if (string.IsNullOrEmpty(row) || !_agentPattern.IsMatch(row))
        {
            throw new InvalidRowFormatException(row);    
        }
    }

    public static void ThrowIfInvalidLocation(string location)
    {
        if (string.IsNullOrEmpty(location) || !_locationPattern.IsMatch(location))
        {
            throw new InvalidRowFormatException($"location: {location}");    
        }
    }
}