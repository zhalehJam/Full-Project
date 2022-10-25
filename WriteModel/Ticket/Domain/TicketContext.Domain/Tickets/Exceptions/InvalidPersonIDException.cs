using Framework.Domain;
using TicketContext.Resource;

namespace TicketContext.Domain.Tickets.Exceptions
{
    public class InvalidPersonIDException:DomainException
    {
        public override string Message => TicketResource.InvalidPersonIDException;
    }
}
