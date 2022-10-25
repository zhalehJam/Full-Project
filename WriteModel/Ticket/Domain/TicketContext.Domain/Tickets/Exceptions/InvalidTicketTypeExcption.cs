using Framework.Domain;
using TicketContext.Resource;

namespace TicketContext.Domain.Tickets.Exceptions
{
    public class InvalidTicketTypeExcption:DomainException
    {
        public override string Message => TicketResource.InvalidTicketTypeExcption;
    }
}
