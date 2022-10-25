using Framework.Domain;
using TicketContext.Resource;

namespace TicketContext.Domain.Tickets.Exceptions
{
    public class InvalidTicketConditionExcption:DomainException
    {
        public override string Message => TicketResource.InvalidTicketConditionExcption;
    }
}
