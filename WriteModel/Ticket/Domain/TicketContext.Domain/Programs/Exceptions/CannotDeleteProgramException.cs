using Framework.Domain;
using TicketContext.Resource;

namespace TicketContext.Domain.Programs.Exceptions
{
    public class CannotDeleteProgramException:DomainException
    {
        public override string Message => ProgramResource.CannotDeleteProgramException;
    }
}
