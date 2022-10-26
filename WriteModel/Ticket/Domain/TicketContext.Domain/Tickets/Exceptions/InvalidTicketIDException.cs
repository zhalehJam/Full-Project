using Framework.Domain;
using TicketContext.Resource;

namespace TicketContext.Domain.Tickets.Exceptions
{
    public class InvalidTicketIDException:DomainException
    {
        public override string Message => TicketResource.InvalidTicketIDException;
    }
}
