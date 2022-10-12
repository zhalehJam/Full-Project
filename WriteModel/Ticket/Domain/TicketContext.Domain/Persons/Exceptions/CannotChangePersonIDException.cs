using Framework.Domain;
using TicketContext.Resource;

namespace TicketContext.Domain.Persons.Exceptions
{
    public class CannotChangePersonIDException : DomainException
    {
        public override string Message => PersonResource.CannotChangePersonIDException;
    }

}

