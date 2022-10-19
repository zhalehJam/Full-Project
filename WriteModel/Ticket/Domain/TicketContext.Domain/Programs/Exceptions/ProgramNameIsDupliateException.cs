using Framework.Domain;
using TicketContext.Resource;

namespace TicketContext.Domain.Programs.Exceptions
{
    public class ProgramNameIsDupliateException:DomainException
    {
        public override string Message => ProgramResource.ProgramNameIsDupliateException;
    }
}
