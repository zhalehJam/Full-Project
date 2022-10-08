using Framework.Domain;
using TicketContext.Resource;

namespace TicketContext.Domain.Centers.Exceptions
{
    public class CenterIDDuplicationException : DomainException
    {
        public override string Message => CenterResource.CenterIDDuplicationException;
    }
    
}
