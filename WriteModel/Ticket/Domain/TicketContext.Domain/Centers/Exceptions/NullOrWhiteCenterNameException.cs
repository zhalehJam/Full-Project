using Framework.Domain;
using TicketContext.Resource;

namespace TicketContext.Domain.Centers.Exceptions
{
    public class NullOrWhiteCenterNameException:DomainException
    {
        public override string Message => CenterResource.NullOrWhiteCenterNameException;
    }
    
}
