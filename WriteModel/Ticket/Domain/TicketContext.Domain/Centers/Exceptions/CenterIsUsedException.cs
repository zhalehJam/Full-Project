using Framework.Domain;
using TicketContext.Resource;

namespace TicketContext.Domain.Centers.Exceptions
{
    public class CenterIsUsedException : DomainException
    {
        public override string Message => CenterResource.CenterIsUsedException;
    }
}
