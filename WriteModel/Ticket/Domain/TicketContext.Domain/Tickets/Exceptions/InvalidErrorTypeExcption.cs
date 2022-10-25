using Framework.Domain;
using TicketContext.Resource;

namespace TicketContext.Domain.Tickets.Exceptions
{
    public class InvalidErrorTypeExcption:DomainException
    {
        public override string Message => TicketResource.InvalidErrorTypeExcption;
    }
}
