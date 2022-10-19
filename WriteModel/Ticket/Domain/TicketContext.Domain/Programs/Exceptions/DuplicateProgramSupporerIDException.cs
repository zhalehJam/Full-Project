using Framework.Domain;
using TicketContext.Resource;

namespace TicketContext.Domain.Programs.Exceptions
{
    public class DuplicateProgramSupporerIDException :DomainException
    {
        public override string Message => ProgramResource.DuplicateProgramSupporerIDException;
    }
}
