using Framework.Domain;
using TicketContext.Resource;

namespace TicketContext.Domain.Centers.Exceptions
{
    public class CenterIDIsNotValidException : DomainException
    {
        public override string Message => CenterResource.CenterIDIsNotValidException;
    }
    
}
