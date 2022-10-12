using Framework.Domain;
using TicketContext.Resource;

namespace TicketContext.Domain.Persons.Exceptions
{
    public class PartIDIsNotValidException : DomainException
    {
        public override string Message => PersonResource.PartIDIsNotValidException;
    }

}

