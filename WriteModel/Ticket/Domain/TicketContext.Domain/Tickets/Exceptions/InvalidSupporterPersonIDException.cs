using Framework.Domain;
using TicketContext.Resource;

namespace TicketContext.Domain.Tickets.Exceptions
{
    public class InvalidSupporterPersonIDException:DomainException
    {
        public override string Message => TicketResource.InvalidSupporterPersonIDException;
    }
}
