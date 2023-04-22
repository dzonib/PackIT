using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Polisies;

public interface IPackingItemsPolicy
{
    bool IsApplicable(PolicyData data);
    IEnumerable<PackingItem> GenerateItems(PolicyData data);
}