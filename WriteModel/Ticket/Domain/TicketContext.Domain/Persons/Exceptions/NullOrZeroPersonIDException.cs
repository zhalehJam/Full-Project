using Framework.Domain;
using TicketContext.Resource;

namespace TicketContext.Domain.Persons.Exceptions
{
    public class NullOrZeroPersonIDException : DomainException
    {
        public override string Message => PersonResource.NullOrZeroPersonIDException;
    }
    
}

