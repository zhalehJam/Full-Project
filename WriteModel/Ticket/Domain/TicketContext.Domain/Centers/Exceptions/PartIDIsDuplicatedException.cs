using Framework.Domain;
using TicketContext.Resource;

namespace TicketContext.Domain.Centers.Exceptions
{
    public class PartIDIsDuplicatedException : DomainException
    {
        public override string Message => CenterResource.PartIDIsDuplicatedException;
    }
    

}
