using Framework.Domain;
using TicketContext.Resource;

namespace TicketContext.Domain.Programs.Exceptions
{
    public class ProgramNameIsDuplicateException:DomainException
    {
        public override string Message => ProgramResource.ProgramNameIsDuplicateException;
    }
}
