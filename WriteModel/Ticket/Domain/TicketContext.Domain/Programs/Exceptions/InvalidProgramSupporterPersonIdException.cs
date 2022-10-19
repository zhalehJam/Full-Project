using Framework.Domain;
using TicketContext.Resource;

namespace TicketContext.Domain.Programs.Exceptions
{
    public class InvalidProgramSupporterPersonIdException:DomainException
    {
        public override string Message => ProgramResource.InvalidProgramSupporterPersonIdException;
    }
}
