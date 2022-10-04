using Framework.Domain;
using TicketContext.Resource;

namespace TicketContext.Domain.Centers.Exceptions
{
    public class ZeroCenterIDException : DomainException
    {
        public override string Message => CenterResource.ZeroCenterIDException;
    }
    public class CenterIDIsnotFindInHRException : DomainException
    {
        public override string Message => CenterResource.CenterIDIsnotFindInHRException;
    }
    
}
