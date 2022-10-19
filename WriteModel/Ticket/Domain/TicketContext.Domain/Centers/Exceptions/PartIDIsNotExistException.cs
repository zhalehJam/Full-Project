using Framework.Domain;
using TicketContext.Resource;

namespace TicketContext.Domain.Centers.Exceptions
{
    public class PartIDIsNotExistException : DomainException
    {
        public override string Message => CenterResource.PartIDIsNotExistException;
    }
}
