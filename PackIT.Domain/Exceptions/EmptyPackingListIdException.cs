using PackIT.Shared.Abstractions.Exceptions;

namespace PackIT.Domain.Exceptions;

public class EmptyPackingListIdException : PackITException
{
    public EmptyPackingListIdException() : base("packing list ID can not be empty.")
    {
    }
}