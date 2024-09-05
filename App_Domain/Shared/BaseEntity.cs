using System.ComponentModel.DataAnnotations.Schema;

namespace Book_Domain.Shared
{
    public class BaseEntity
    {
        public long Id { get; private set; }
        public DateTime CreationDate { get; }
        public BaseEntity()
        {
            CreationDate = new DateTime();
        }
    }
    public class BaseDomainEvent
    {
        public DateTime CreationDate { get; }
        public BaseDomainEvent()
        {
            CreationDate = new DateTime();
        }
    }
    public class AggregateRoot : BaseEntity
    {
        // back field
        private readonly List<BaseDomainEvent> _domainEvent = new List<BaseDomainEvent>();

        [NotMapped]
        public List<BaseDomainEvent> DomainEvents => _domainEvent;

        public void AddDomainEvent(BaseDomainEvent eventItem)
        {
            _domainEvent.Add(eventItem);
        }
        public void RemoveDomainEvent(BaseDomainEvent eventItem)
        {
            _domainEvent?.Remove(eventItem);
        }
    }
}
