using Framework.Domain;
using TicketContext.Resource;

namespace TicketContext.Domain.Persons.Exceptions
{
    public class InvalidPersonIDException : DomainException
    {
        public override string Message => PersonResource.InvalidPersonIDException;
    }
    
}

