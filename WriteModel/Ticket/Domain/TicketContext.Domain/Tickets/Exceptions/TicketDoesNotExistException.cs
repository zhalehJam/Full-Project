using Framework.Domain;
using TicketContext.Resource;

namespace TicketContext.Domain.Tickets.Exceptions
{
    public class TicketCannotDeletetException:DomainException
        {
        public override string Message => TicketResource.TicketCannotDeletetException;
    }
}
