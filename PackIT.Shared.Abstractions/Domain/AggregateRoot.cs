namespace PackIT.Shared.Abstractions.Domain;

public abstract class AggregateRoot<T>
{
    public T Id { get; set; }
    public int Version { get; protected set; }
    public IEnumerable<IDomainEvent> Events => _events;

    private bool _versionIncremented;

    private readonly List<IDomainEvent> _events = new();
    
    // we want to use it only within our aggregate
    protected void AddEvent(IDomainEvent @event)
    {
        if (!_events.Any() && !_versionIncremented)
        {
            Version++;
            _versionIncremented = true;

            _events.Add(@event);
        }
    }

    public void ClearEvents() => _events.Clear();
    
    protected void IncrementVersion()
    {
        if (_versionIncremented)
        {
            return;
        }

        Version++;
        _versionIncremented = true;
    }
}