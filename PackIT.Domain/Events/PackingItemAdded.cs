using PackIT.Domain.Entities;
using PackIT.Domain.ValueObjects;
using PackIT.Shared.Abstractions.Domain;

namespace PackIT.Domain.Events;

// can be of any type, we will make it record, as it is immutable
public record PackingItemAdded(PackingList PackingList, PackingItem PackingItem) : IDomainEvent;