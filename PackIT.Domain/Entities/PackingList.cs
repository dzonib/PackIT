using PackIT.Domain.Events;
using PackIT.Domain.Exceptions;
using PackIT.Domain.ValueObjects;
using PackIT.Shared.Abstractions.Domain;

namespace PackIT.Domain.Entities;

// entities by nature are mutable

// aggregate will be responsible for keeping the consistency between transaction
// keeping data that comes valid and keeping business rules in aggregate needs to be fulfilled
public class PackingList : AggregateRoot<PackingListId>
{
    // domain logic needs to stay in domain
    // for ex. in application layer, based on Name and Localization, execute something
    // we should do domain logic in domain leray
    public PackingListId Id { get; private set; }
    
    // public string Name { get; private set; }
    // public string Localization { get; private set; }
    
    // change properties to private fields, to prevent use of domain fields in other layers
    // we will need to adjust logic because of this, it is harder to work with this
    // we do this in favor in DDD
    
    // we use value object in stead of primitive value (string)
    // value objects are doing validation, we are not doing it in here
    
    // private string _name;
    private readonly PackingListName _name;
    private Localization _localization;

    private readonly LinkedList<PackingItem> _items = new();

    // call second overload
    // private PackingList(PackingListId id, PackingListName name, Localization localization, LinkedList<PackingItem> items)
    //     :this(id, name, localization)
    // {
    //     // _items = items;
    //     AddItems(items);
    // }
    
    // we will call constructor by some sort of factory, we do not want to call this directly from application layer
    internal PackingList(PackingListId id, PackingListName name, Localization localization)
    {
        Id = id;
        _name = name;
        _localization = localization;
    }

    public void AddItem(PackingItem item)
    {
        // we want to avoid duplicates
        var alreadyExists = _items.Any(i => i.Name == item.Name);

        if (alreadyExists)
        {
            throw new PackingItemAlreadyExistsException(_name, item.Name);
        }

        _items.AddLast(item);
        
        // domain event - represent important action that already happened within our system, we can not undo it
        AddEvent(new PackingItemAdded(this, item));
    }

    public void AddItems(IEnumerable<PackingItem> items)
    {
        // this was the purpose of adding version guard to check if version vas previously incremented or not
        foreach (var item in items)
        {
            AddItem(item);
        }
    }

    public void PackItem(string itemName)
    {
        var item = GetItem(itemName);
        
        // make a copy of a record, with changed property
        // other primitives within the object will be copied, we dont need to assign them explicitly
        var packedItem = item with { IsPacked = true };

        // replace it without changing order
        _items.Find(item).Value = packedItem;
        AddEvent(new PackingItemPacked(this, item));
    }

    public void RemoveItem(string itemName)
    {
        var item = GetItem(itemName);
        _items.Remove(item);
        AddEvent(new PackingItemRemoved(this, item));
    }

    private PackingItem GetItem(string itemName)
    {
        var item = _items.SingleOrDefault(x => x.Name == itemName);

        if (item is null)
        {
            throw new PackingItemNotFoundException(itemName);
        }
        return item;
    }
}
// we can think about policy as a domain representation of a strategy pattern
// i want to have decoupled way of putting conditions to the separated classes
