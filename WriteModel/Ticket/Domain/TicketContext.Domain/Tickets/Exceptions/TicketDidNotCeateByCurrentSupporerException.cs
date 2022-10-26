using Framework.Domain;
using TicketContext.Resource;

namespace TicketContext.Domain.Tickets.Exceptions
{
    public class TicketDidNotCeateByCurrentSupporerException:DomainException
    {
        public override string Message => TicketResource.TicketDidNotCeateByCurrentSupporerException;
    }
}
