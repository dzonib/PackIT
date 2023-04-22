namespace PackIT.Domain.ValueObjects;

// will be used by some sort of weather api, to get info and make packing decision
public record Localization(string City, string Country)
{
    // simple factory method
    public static Localization Create(string value)
    {
        var splitLocalization = value.Split(',');

        return new Localization(splitLocalization.First(), splitLocalization.Last());
    }

    public override string ToString()
        => $"{City}, {Country}";
}