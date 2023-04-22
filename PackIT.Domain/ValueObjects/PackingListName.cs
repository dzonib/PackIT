using PackIT.Domain.Exceptions;

namespace PackIT.Domain.ValueObjects;

// value objects are by nature immutable
public record PackingListName
{
    public string Value { get; set; }

    public PackingListName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyPackingListNameException();
        }
        
        Value = value;
    }
    
    // conversion from value object to string
    public static implicit operator string(PackingListName name)
        => name.Value;
    
    // conversion from string to value object
    public static implicit operator PackingListName(string name)
        => new(name);
}