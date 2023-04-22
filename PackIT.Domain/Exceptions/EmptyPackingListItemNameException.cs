using PackIT.Shared.Abstractions.Exceptions;

namespace PackIT.Domain.Exceptions;

public class EmptyPackingListItemNameException : PackITException
{
    public EmptyPackingListItemNameException() : base("packing item name can not be empty.")
    {
    }
}