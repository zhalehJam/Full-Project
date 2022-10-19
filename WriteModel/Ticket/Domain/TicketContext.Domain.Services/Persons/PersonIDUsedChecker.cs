using TicketContext.Domain.Persons.DomainServices;
using TicketContext.Domain.Programs.DomainServices;

namespace TicketContext.Domain.Services.Persons
{
    public class PersonIDUsedChecker : IPersonIDUsedChecker
    {
        private readonly IProgramRepository _programRepository;

        public PersonIDUsedChecker(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }
        public bool IsUsed(int personID)
        {
            bool isUsed = false;
            if(_programRepository.IsExist(n=>n.ProgramSupporters
                                              .Where(p=>p.SupporterPersonID==personID)
                                              .FirstOrDefault()!=null))
            {
                isUsed = true;
            }
            return isUsed;
        }
    }
}
