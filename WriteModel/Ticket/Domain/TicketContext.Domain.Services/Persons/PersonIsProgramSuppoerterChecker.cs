using TicketContext.Domain.Persons.DomainServices;
using TicketContext.Domain.Programs.DomainServices;

namespace TicketContext.Domain.Services.Persons
{
    public class PersonIsProgramSupporterChecker : IPersonIsProgramSupporterChecker
    {
        readonly IProgramRepository _programRepository;
        public PersonIsProgramSupporterChecker(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }
        public bool IsSupporter(int personId)
        {
            return _programRepository.IsExist(p => p.ProgramSupporters.Any(s => s.SupporterPersonID == personId));
        }
    }
}
