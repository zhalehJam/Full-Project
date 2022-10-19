using Framework.Domain;
using TicketContext.Resource;

namespace TicketContext.Domain.Programs.Exceptions
{
    public class SupporterIdIsNotValidException:DomainException
    {
        public override string Message => ProgramResource.SupporterIdIsNotValidException;
    }
}
