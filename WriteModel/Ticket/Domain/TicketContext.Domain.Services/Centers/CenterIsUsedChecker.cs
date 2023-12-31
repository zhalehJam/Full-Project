using TicketContext.Domain.Centers.DomainServices;
using TicketContext.Domain.Persons.DomainServices;
using TicketContext.Domain.Tickets.DomainServices;

namespace TicketContext.Domain.Services.Centers
{
    public class CenterIsUsedChecker : ICenterIsUsedChecker
    {
        private readonly IPersonRepository _personRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly ICenterRepository _centerRepository;

        public CenterIsUsedChecker(IPersonRepository personRepository, ITicketRepository ticketRepository, ICenterRepository centerRepository)
        {
            _personRepository = personRepository;
            _ticketRepository = ticketRepository;
            _centerRepository = centerRepository;
        }
        public bool IsUsed(Guid Id)
        {
            List<Guid> partids = new List<Guid>();
            partids = _centerRepository.GetByID(Id).Parts.Select(x => x.Id).ToList(); 
            return _personRepository.IsExist(n => partids.Contains(n.PartId))
            ||
                _ticketRepository.IsExist(n => partids.Contains(n.PersonPartId));
        }
    }

}