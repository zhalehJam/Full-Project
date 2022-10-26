using Framework.Domain;
using TicketContext.Resource;

namespace TicketContext.Domain.Tickets.Exceptions
{
    public class TheCompetedTicketCannotUpdateEception:DomainException
    {
        public override string Message => TicketResource.TheCompetedTicketCannotUpdateEception;
    }
}
