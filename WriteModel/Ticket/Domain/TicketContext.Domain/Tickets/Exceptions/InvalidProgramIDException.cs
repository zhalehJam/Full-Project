using Framework.Domain;
using TicketContext.Resource;

namespace TicketContext.Domain.Tickets.Exceptions
{
    public class InvalidProgramIDException:DomainException
    {
        public override string Message => TicketResource.InvalidProgramIDException;
    }
}
