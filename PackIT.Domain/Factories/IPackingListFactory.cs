using PackIT.Domain.Consts;
using PackIT.Domain.Entities;
using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Factories;
// factory: place in the code which will be responsible for creating/constructing our aggregates
// we dont want any knowledge on how this gets created we want it to delegate it to factory method that does the job
public interface IPackingListFactory
{
    // creates packing list with no items
    PackingList Create(PackingListId id, PackingListName name, Localization localization);
    
    // includes additional data that comes from user input
    PackingList CreateWithDefaultItems(PackingListId id, PackingListName name, TravelDays days, Gender gender,
        Temperature temperature, Localization localization);
}