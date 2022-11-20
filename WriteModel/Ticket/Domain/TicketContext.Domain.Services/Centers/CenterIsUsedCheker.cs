using TicketContext.Domain.Centers.DomainServices;
using TicketContext.Domain.Persons.DomainServices;
using TicketContext.Domain.Tickets.DomainServices;

namespace TicketContext.Domain.Services
{
    public class CenterIsUsedCheker : ICenterIsUsedCheker
    {
        private readonly IPersonRepository _personRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly ICenterRepository _centerRepository;

        public CenterIsUsedCheker(IPersonRepository personRepository, ITicketRepository ticketRepository, ICenterRepository centerRepository)
        {
            _personRepository = personRepository;
            _ticketRepository = ticketRepository;
            _centerRepository = centerRepository;
        }
        public bool IsUsed(Guid Id)
        {
            List<Guid> partids = new List<Guid>();
            partids = _centerRepository.GetByID(Id).Parts.Select(x => x.Id).ToList();
            //var t = _ticketRepository.IsExist(n => partids.Contains(n.PersonPartId));
            return _personRepository.IsExist(n => partids.Contains(n.Id))
            ||
                _ticketRepository.IsExist(n => partids.Contains(n.PersonPartId));
        }
    }

}