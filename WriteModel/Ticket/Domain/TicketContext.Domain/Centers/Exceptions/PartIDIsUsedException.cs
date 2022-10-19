using Framework.Domain;
using TicketContext.Resource;

namespace TicketContext.Domain.Centers.Exceptions
{
    public class PartIDIsUsedException:DomainException
    {
        public override string Message => CenterResource.PartIDIsUsedException;
    }



}
