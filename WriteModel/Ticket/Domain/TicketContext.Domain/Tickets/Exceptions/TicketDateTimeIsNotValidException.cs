using Framework.Domain;
using TicketContext.Resource;

namespace TicketContext.Domain.Tickets.Exceptions
{
    public class TicketDateTimeIsNotValidException:DomainException
    {
        public override string Message => TicketResource.TicketDateTieIsNotValidException;
    }
}
