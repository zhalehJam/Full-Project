using Framework.Domain;
using TicketContext.Resource;

namespace TicketContext.Domain.Centers.Exceptions
{
    public class PartIDIsNotValidException : DomainException
    {
        public override string Message => CenterResource.PartIDIsNotValidException;
    }
    
}
