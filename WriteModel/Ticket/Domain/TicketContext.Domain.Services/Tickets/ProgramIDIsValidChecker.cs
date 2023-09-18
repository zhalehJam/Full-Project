using TicketContext.Domain.Programs.DomainServices;
using TicketContext.Domain.Tickets.DomainServices;

namespace TicketContext.Domain.Services.Tickets
{
    public class ProgramIDValidationChecker : IProgramIDValidationChecker
    {
        private readonly IProgramRepository _programRepository;

        public ProgramIDValidationChecker(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }
        public bool IsValid(Guid programId)
        {
            bool isValid = _programRepository.IsExist(n => n.Id.Equals(programId));
            return isValid;
        }
    }
}
