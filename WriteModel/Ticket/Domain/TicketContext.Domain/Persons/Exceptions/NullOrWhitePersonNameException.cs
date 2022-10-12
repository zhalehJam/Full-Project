using Framework.Domain;
using TicketContext.Resource;

namespace TicketContext.Domain.Persons.Exceptions
{
    public class NullOrWhitePersonNameException :DomainException
    {
        public override string Message => PersonResource.NullOrWhitePersonNameException;
    }
    
}

