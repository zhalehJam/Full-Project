using Framework.Domain;
using TicketContext.Resource;

namespace TicketContext.Domain.Centers.Exceptions
{
    public class NullOrWhitePartNameException : DomainException
    {
        public override string Message => CenterResource.NullOrWhitePartNameException;
    }
    

}
