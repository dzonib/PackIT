using PackIT.Domain.Consts;
using PackIT.Domain.Entities;
using PackIT.Domain.Polisies;
using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Factories;

// factory: place in the code which will be responsible for creating/constructing our aggregates
// we dont want any knowledge on how this gets created we want it to delegate it to factory method that does the job
public class PackingListFactory : IPackingListFactory
{
    private readonly IEnumerable<IPackingItemsPolicy> _policies;

    public PackingListFactory(IEnumerable<IPackingItemsPolicy> policies)
    => _policies = policies;

    public PackingList Create(PackingListId id, PackingListName name, Localization localization)
        => new(id, name, localization);

    public PackingList CreateWithDefaultItems(PackingListId id, PackingListName name, TravelDays days, Gender gender,
        Temperature temperature, Localization localization)
    {
        var data = new PolicyData(days, gender, temperature, localization);

        var applicablePolicies = _policies.Where(p => p.IsApplicable(data));

        var items = applicablePolicies.SelectMany(p => p.GenerateItems(data));

        var packingList = Create(id, name, localization);
        
        packingList.AddItems(items);
        
        // factory will take care of the whole process of constructing
        // but the protecting invariants is within the aggregate
        // it knows what rules needs to be fulfilled when we are adding items

        return packingList;
    }
}