using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Primitives
{
    public abstract class AgregateRoot
    {
        private readonly List<DomainEvent> domainEvents = new List<DomainEvent>();

        public ICollection<DomainEvent> DomainEvents => domainEvents;


        protected void Raise (DomainEvent domainEvent)
        {
            domainEvents.Add(domainEvent);
        }
    }
}
