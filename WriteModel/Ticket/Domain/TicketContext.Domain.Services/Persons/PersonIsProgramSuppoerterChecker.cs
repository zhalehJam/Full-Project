using TicketContext.Domain.Persons.DomainServices;
using TicketContext.Domain.Programs.DomainServices;

namespace TicketContext.Domain.Services.Persons
{
    public class PersonIsProgramSuppoerterChecker : IPersonIsProgramSuppoerterChecker
    {
        IProgramRepository _programRepository;
        public PersonIsProgramSuppoerterChecker(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }
        public bool IsSupprter(int perosnId)
        {
            return _programRepository.IsExist(p => p.ProgramSupporters.Any(s => s.SupporterPersonID == perosnId));
        }
    }
}
