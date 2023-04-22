using PackIT.Shared.Abstractions.Exceptions;

namespace PackIT.Domain.Exceptions;

public class PackingItemNotFoundException : PackITException
{
    // not needing this at the moment
    public string ItemName { get; }

    public PackingItemNotFoundException(string itemName) : base($"packing item '{itemName}' was not found")
    => ItemName = itemName;
    
}