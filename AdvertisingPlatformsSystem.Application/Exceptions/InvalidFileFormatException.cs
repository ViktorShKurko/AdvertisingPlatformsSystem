namespace AdvertisingPlatformsSystem.Exceptions;

public class InvalidFileFormatException : Exception
{
    public InvalidFileFormatException(string trueFormat) : base(message: $"Invalid file format, must be {trueFormat}") {}
}

public class InvalidRowFormatException : Exception
{
    public InvalidRowFormatException(string row) : base(message: $"Row format is invalid {row}") {}
}