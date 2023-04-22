using PackIT.Shared.Abstractions.Exceptions;

namespace PackIT.Domain.Exceptions;

// it is ok if we reference abstractions in domain layer, if they dont introduce any I/O
// we can also move it to domain package if we want it clean
public class EmptyPackingListNameException : PackITException
{
    public EmptyPackingListNameException() : base("packing list name is empty.")
    {
    }
}