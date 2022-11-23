using TicketContext.Domain.Persons.DomainServices;
using TicketContext.Domain.Programs.DomainServices;
using TicketContext.Domain.Tickets.DomainServices;

namespace TicketContext.Domain.Services.Persons
{
    public class PersonIDUsedChecker : IPersonIDUsedChecker
    {
        private readonly IProgramRepository _programRepository;
        private readonly ITicketRepository _ticketRepository;

        public PersonIDUsedChecker(IProgramRepository programRepository,
            ITicketRepository ticketRepository)
        {
            _programRepository = programRepository;
            _ticketRepository = ticketRepository;
        }
        public bool IsUsed(int personID)
        {
            bool isUsed = false;
            return (_programRepository.IsExist(n => n.ProgramSupporters
                                              .Where(p => p.SupporterPersonID == personID)
                                              .FirstOrDefault() != null) ||
                    _ticketRepository.IsExist(n => n.SupporterPersonID.Equals(personID) || n.PersonID.Equals(personID)));

            
        }
    }
}
