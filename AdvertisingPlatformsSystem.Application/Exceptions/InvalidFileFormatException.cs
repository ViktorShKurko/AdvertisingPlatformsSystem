namespace AdvertisingPlatformsSystem.Exceptions;

public class InvalidFileFormatException(string trueFormat)
    : Exception(message: $"Invalid file format, must be {trueFormat}");

public class InvalidRowFormatException(string row) : Exception(message: $"Row format is invalid {row}");