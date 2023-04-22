using PackIT.Shared.Abstractions.Exceptions;

namespace PackIT.Domain.Exceptions;

public class InvalidTravelDaysException : PackITException
{
    public ushort Days { get; }

    public InvalidTravelDaysException(ushort days) : base($"value '{days}' has invalid travel days.")
        => Days = days;
    
}