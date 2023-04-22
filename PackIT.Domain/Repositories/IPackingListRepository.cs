using PackIT.Domain.Entities;
using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Repositories;

// contract what we are capable of doing within  our domain
public interface IPackingListRepository
{
    Task<PackingList> GetAsync(PackingListId id);
    Task AddAsync(PackingList packingList);
    Task UpdateAsync(PackingList packingList);
    Task DeleteAsync(PackingList packingList);
}